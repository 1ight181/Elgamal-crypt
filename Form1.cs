using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Elgamal_crypt_для_конфы
{
    public partial class Form1 : Form
    {
        //это прототип, вычисление первообразного корня не всегда верно,
        //можно исправить, нужна факторизация и упрощение степеней
        //но для исследования скорости шифрованяи достаточно, так как можно подставить готовые значения, не используя вычислений

        //сколькими битами кодируется один символ, используется представление в UTF-16
        const int charSize = 16;

        //открытый ключ
        int pNumber; //большое простое
        int gNumber; //первообразный корень от p
        int yNumber; //y=g^x mod p

        //закрытый ключ
        int xNumber; //1 < x < p - 1 

        //сессионный ключ
        int kNumber; //1 < k < p - 1; k - взаимнопростое с p-1

        //шифротекст
        int aNumber; //a = g^k mod p 

        //рандомайзер
        Random rnd = new Random();

        int kf = 1;

        public Form1()
        {
            InitializeComponent();
        }


        //создание системы Эль-Гамаля
        private void createElgamalSysButton_Click(object sender, EventArgs e)
        {
            //создаем открытый ключ(p, g, y) и закрытый (x)
            pNumber = CreatePrime();
            gNumber = CreatePrimitiveRoot(pNumber);
            xNumber = rnd.Next(1, pNumber - 1);
            yNumber = (int)(BigInteger.Pow(gNumber, xNumber) % pNumber); //y=g^x mod p

            //выводим открытый ключ
            publicKeyText.Text = yNumber.ToString() + ' ' + gNumber.ToString() + ' ' + pNumber.ToString();

            //выводим закрытый ключ
            privateKeyText.Text = xNumber.ToString();

            //создаем сессионный ключ
            kNumber = rnd.Next(256, pNumber - 1);

            //выводим сессионный ключ
            sessionalKeyText.Text = kNumber.ToString();

            //считаем aNumber
            aNumber = (int)(BigInteger.Pow(gNumber, kNumber) % pNumber);
        }

        //шифрование
        private void encryptButton_Click(object sender, EventArgs e)
        {
            //берем значение сообщения
            string message = messageText.Text;

            //объявляем массив кодов для каждого из символов сообщения
            int[] codes = new int[message.Length];

            //переводим каждый символ в коды
            for (int i = 0; i < message.Length; i++)
            {
                codes[i] = Convert.ToInt32(CharToBinaryFormat(message[i]), 2);

            }

            //объявляем массивы зашифрованных кодов для каждого из символов сообщения (a и b)
            int[] bEncryptedCodes = new int[message.Length];

            //объявляем строку зашифрованного сообщения
            string encryptedStr;
            messageText.Text = "";
            messageText.Text = messageText.Text + StringFromBinaryToNormalFormat(Convert.ToString(aNumber * kf, 2));

            for (int i = 0; i < message.Length; i++)
            {
                bEncryptedCodes[i] = (int)((BigInteger.Pow(yNumber, kNumber) * codes[i]) % pNumber) * kf;
                //messageText.Text = messageText.Text + (bEncryptedCodes[i] / kf).ToString();
                encryptedStr = Convert.ToString(bEncryptedCodes[i], 2);
                messageText.Text = messageText.Text + StringFromBinaryToNormalFormat(encryptedStr);
            }
        }

        //расшифровка
        private void decryptButton_Click(object sender, EventArgs e)
        {
            //берем значение сообщения
            string message = messageText.Text;

            //объявляем массив кодов для каждого из символов сообщения
            int[] codes = new int[message.Length];

            //переводим каждый символ в коды
            for (int i = 0; i < message.Length; i++)
            {
                codes[i] = Convert.ToInt32(CharToBinaryFormat(message[i]), 2);
            }

            aNumber = (codes[0] / kf);
            messageText.Text = "";
            for (int i = 1; i < message.Length; i++)
            {
                messageText.Text = messageText.Text + StringFromBinaryToNormalFormat(Convert.ToString(((int)(codes[i] / kf * BigInteger.Pow(aNumber, pNumber - 1 - xNumber) % pNumber)), 2));
            }
        }

        //метод возвращает истину если число простое, ложь в противном случае
        private bool IsPrime(int primeNumber)
        {
            bool result = true;

            for (int i = 2; i <= primeNumber / 2; i++)
            {
                if (primeNumber % i == 0)
                {
                    return result = false;
                }
            }
            return result;
        }

        //метод генерирует простое число
        private int CreatePrime()
        {
            int primeNumber = rnd.Next(512, 1024);

            //перегенирируем до тех пор, пока число не будет простым
            while (!IsPrime(primeNumber))
            {
                primeNumber = rnd.Next(512, 1024);
            }

            return primeNumber;
        }

        //метод возвращающий истину, если числа взаимопростые, ложь в противном случае
        private bool IsCoprime(int firstNumber, int secondNumber)
        {
            if (firstNumber % secondNumber != 0 && secondNumber % firstNumber != 0)
                return true;
            else
                return false;
        }

        //метод для нахождения всех делителей некоторого числа
        private List<int> FindAllDividers(int dividend)
        {
            List<int> dividers = new List<int>(); 
            for (int i = 2; i < dividend; i++)                
                if (dividend % i == 0)
                    dividers.Add(i);
            return dividers;
        }

        //метод возвращающий истину, если число первообразный корень другого некоторого числа,
        //ложь в противном случае
        private bool IsPrimitiveRoot(int gNumber, int pNumber)
        {
            List<int> dividers = FindAllDividers(pNumber - 1);
            BigInteger pNum = pNumber;
            BigInteger gNum = gNumber;       

            foreach (int divider in dividers)
            {
                if ((BigInteger.Pow(gNum, divider) - 1) % pNum == 0)
                    return false;    
            }
            return true;
        }

        //возвращает первообразный корень по модулю pNumber, возвращает ноль, если такового нет
        private int CreatePrimitiveRoot(int pNumber)
        { 
            for(int i = 256; i < pNumber; i++)
            {
                if (IsPrimitiveRoot(i, pNumber))
                    return i;
            }
            return 0;
        }

        private string StringFromBinaryToNormalFormat(string str)
        {
            string output = "";

            int resultNumber = 0;
            int degree = str.Length - 1;

            foreach (char ch in str)
                resultNumber += Convert.ToInt32(ch.ToString()) * (int)Math.Pow(2, degree--);

            output = ((char)resultNumber).ToString();

            return output;
        }

        private string CharToBinaryFormat(char ch)
        {
            string out_str = "";

            string char_binary = Convert.ToString(ch, 2);

            while (char_binary.Length < charSize)
                char_binary = "0" + char_binary;

            out_str += char_binary;

            return out_str;
        }
    }
}
