using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICROSSCommon
{
    public class ColumnNumber
    {
        public string Text { get => GetText(); }

        public IEnumerable<PanelButtonBase> Buttons { get; set; }

        public ColumnNumber(int row, IEnumerable<PanelButtonBase> buttons)
        {
            if (row < 0) { throw new ArgumentOutOfRangeException(nameof(row)); }
            if (buttons == null) { throw new ArgumentNullException(nameof(buttons)); }
            Buttons = buttons;
        }

        private string GetText()
        {
            var nums = new List<int>();
            int count = 0;

            foreach (var button in Buttons)
            {
                if (button is CheckedPanelButton)
                {
                    count++;
                }
                if (button is DefaultPanelButton)
                {
                    if (count > 0)
                    {
                        nums.Add(count);
                        count = 0;
                    }
                }
            }
            if (count > 0) { nums.Add(count); }
            if (nums.Count == 0) { return "0"; }

            var text = new StringBuilder();
            foreach (var num in nums)
            {
                text.Append(num.ToString());
                text.Append("\r\n");
            }
            return text.ToString().TrimEnd('\r', '\n');
        }
    }
}
