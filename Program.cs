using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("反转一个句子里的单词");
            string s = "Welcome to joy,let's make an awesome.";
            Console.WriteLine("反转之前:");
            Console.WriteLine(s);
            s = ReverseStr(s);
            Console.WriteLine("反转之后:");
            Console.WriteLine(s);

            Console.WriteLine("计算正方形的边长");
            Console.WriteLine(GetSquareGrid(120, 150));
            Console.ReadLine();

        }
        /// <summary>
        /// 第一题，反转一个句子里的单词的顺序
        /// 我们要想反转单词的顺序，首先我们要读取这个句子，根据逗号或者句号去划分一个个小句子
        /// 然后小句子里根据空格去划分相应的单词,然后将单词拼接起来，
        /// 因为要反转，所以每次拼接单词的时候，都会从第一个位置去拼接
        /// </summary>
        /// <param name="str">具体要反转的句子</param>
        /// <returns></returns>
        public static string ReverseStr(string str)
        {
            //string的拼接在于new对象，而stringbuilder就不用
            StringBuilder ret = new StringBuilder();//最终反转之后的句子
            StringBuilder tempWorld = new StringBuilder();//每一个句子里的单词
            StringBuilder tempState = new StringBuilder();//每一个句子
            int index = 0;//字符串里字符具体下标

            while (index < str.Length)
            {
                //判断是否读完一个单词
                if (str[index] == ' ')
                {
                    //读完后就添加到句子里
                    tempState.Insert(0, tempWorld);
                    tempState.Insert(0, ' ');
                    tempWorld.Clear();//读完后就清空，防止重复读取
                }
                //判断是否读完一个句子
                else if (str[index] == ',' || str[index] == '.')
                {
                    tempState.Insert(0, tempWorld);
                    tempWorld.Clear();
                    //读完之后，放入反转完成的句子里
                    ret.Append(tempState);
                    ret.Append(str[index]);
                    tempState.Clear();
                }
                //没读完就一直读下去
                else
                {
                    tempWorld.Append(str[index]);
                }
                index++;
            }


            return ret.ToString();
        }
        /// <summary>
        /// 第二题,计算正方形边长
        /// </summary>
        /// <param name="length">矩形区域的长即M</param>
        /// <param name="wide">矩形区域的宽即N</param>
        /// <returns></returns>
        public static int GetSquareGrid(int length, int wide)
        {
            //要想让正方形尽可能填满这个矩形区域，就只能计算正方形的边长在M上的个数与在N上的个数，相乘就是正方形的个数即100个
            //所以，我们要求具体的边长
            //假设边长为x,则M/x*N/x=100,即M*N/x^2=100
            //经过数学公式转化,就变成了M*N=100*x^2
            //也就是x^2=M*N/100，开根号即可,求出来的可能是一个浮点数，强制转化一下
            return (int)Math.Sqrt(length * wide / 100);
        }
    }
   
}
