using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleConsoleMVC
{
    public class FormView
    {
        public List<FormItem> formItems;

        public void Display()
        {
            foreach (var item in formItems)
            {
                if (item is FormEnumItem enumItem)
                {
                    DisplayEnumItems(enumItem);
                }
                else
                {
                    DisplayItem(item);
                }
            }
        }

        private void DisplayEnumItems(FormEnumItem item)
        {
            Console.WriteLine(item.Message);
            int index = 0;
            foreach (var value in Enum.GetValues(item.EnumType))
            {
                Console.WriteLine($"[{index}] - {value}");
            }
            item.SetReference(Console.ReadKey(false).KeyChar.ToString());
        }

        private void DisplayItem(FormItem formItem)
        {
            Console.WriteLine(formItem.Message);
            formItem.SetReference(Console.ReadLine());
        }
    }
}
