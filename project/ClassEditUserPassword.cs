using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class ClassEditUserPassword
    {
        public static bool validPassword(string password)
        {
            if ((password.Length >= 6) && (UpperCase(password) == true) &&
                (number(password) == true) && (character(password) == true) &&
                (repetitive(password) == true) && (LowerCase(password) == true))
            {
                return true;
            }
            else if (password.Length < 6)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل 6 کاراکتر باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (UpperCase(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل شامل یک حرف بزرگ باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (number(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل شامل یک عدد باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (character(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل شامل یک کاراکتر باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (repetitive(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور نباید شامل حروف تکراری باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else if (LowerCase(password) == false)
            {
                System.Windows.Forms.MessageBox.Show("رمز عبور باید حداقل شامل یک حرف کوچک باشد.",
                    "InvalidPassword", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            else
                return false;
        }

        //Uppercase
        private static bool UpperCase(string pass)
        {
            int counter = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsUpper(pass[i]))
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
                return false;
        }

        //number
        private static bool number(string pass)
        {
            int counter = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsDigit(pass[i]))
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
                return false;
        }

        //character
        private static bool character(string pass)
        {
            int counter = 0;
            string characterList = "!@#$%^";
            for (int i = 0; i < characterList.Length; i++)
            {
                if (pass.Contains(characterList[i]))
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
                return false;
        }

        //repetitive
        private static bool repetitive(string pass)
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
            for (int i = 0; i < AlphaPart.Length; i++)
            {
                for (int j = i + 1; j < AlphaPart.Length; j++)
                {
                    if (AlphaPart[i] == AlphaPart[j] )
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

        //Lower Case 
        private static bool LowerCase(string pass)
        {
            int counter = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsLower(pass[i]))
                {
                    counter++;
                }
            }

            if (counter > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
