using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace project
{
    class ClassValidPassword
    {

        public static bool validPassWord(string password)
        {
            if ((password.Length >= 8) && (notConsecutive(password) == true) &&
                (notRepetitive(password) == true))
            {
                return true;
            }
            else if (password.Length < 8)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل 8 کاراکتر باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (notConsecutive(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور نباید شامل اعداد تکراری باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (notRepetitive(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور نباید شامل الگوهای حداقل دو حرفی تکراری  باشد.",
                                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else
                return false;
        }

        //not bew consecutive
        private static bool notConsecutive(string pass)
        {
            //separate numbers from input
            string numPart = string.Empty;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsDigit(pass[i]))
                {
                    numPart += pass[i];
                }
            }
            //if they was consecutive
            bool result = true;
            if (numPart!=null)
            {
                for (int i = 0; i < numPart.Length; i++)
                {
                    int num = numPart[i];
                    for (int j = 0; j < numPart.Length; j++)
                    {
                        if ((num-1==numPart[j])||(num+1==numPart[j]))
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }
            if (result)
            {
                return true;
            }
            return false;
        }

        //not be repetitive
        private static bool notRepetitive(string pass)
        {
            //separate letters from input
            string AlphaPart = string.Empty;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsLetter(pass[i]))
                {
                    AlphaPart += pass[i];
                }
            }
            //if they was repetitive
            bool result = true;
            for (int i = 0; i < AlphaPart.Count() - 2; i++)
            {
                for (int j = i + 1; j < AlphaPart.Count() - 2; j++)
                {
                    if ((AlphaPart[i] == AlphaPart[j]) &&
                        (AlphaPart[i + 1] == AlphaPart[j + 1]) &&
                        (AlphaPart[i + 2] == AlphaPart[j + 2]))
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (result)
            {
                return true;
            }
            return false;
        }
    }
}
