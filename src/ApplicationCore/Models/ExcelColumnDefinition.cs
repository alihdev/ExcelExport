using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fingers10.ExcelExport.Models
{
    /// <summary>
    /// new ExcelColumnDefinition(nameof(entity.Name)),
    /// new ExcelColumnDefinition(nameof(entity.Brief), 1),
    /// new ExcelColumnDefinition(nameof(entity.Brief), 3),
    /// new ExcelColumnDefinition(nameof(entity.IsOnCompany), "Is On Company"),
    /// </summary>
    public class ExcelColumnDefinition
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public int Order { get; set; }

        public ExcelColumnDefinition(string name, string label = "", int order = 0)
        {
            Name = name;
            Label = !string.IsNullOrEmpty(label) ? label : name;
            Order = order;
        }

        public ExcelColumnDefinition(string name, int order)
        {
            Name = name;
            Label = name;
            Order = order;
        }

        public ExcelColumnDefinition()
        {

        }

        /// <summary>
        /// if u defined your list as :
        /// [0, 1, 2, 0, 0, 3]
        /// then will be like :
        /// [1, 2, 3, 0->4, 0->5, 0->6]
        /// </summary>
        public static void ReOrderIfNeed(List<ExcelColumnDefinition> excelColumnDefinitions)
        {
            if (!excelColumnDefinitions.Any(x => x.Order == 0)) return;

            var columnOrder = 0;

            // [0, 1, 2, 0, 0, 3]
            //  |        |  |
            //  4        5  6

            foreach (var excelColumnDefinition in excelColumnDefinitions.Where(x => x.Order == 0))
            {
                while (excelColumnDefinitions.Any(x => x.Order == columnOrder)) columnOrder++;

                excelColumnDefinition.Order = columnOrder;
            }
        }
    }
}
