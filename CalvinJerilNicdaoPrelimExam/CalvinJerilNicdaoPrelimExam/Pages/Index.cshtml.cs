using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalvinJerilNicdaoPrelimExam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]

        public ValueViewModel Value { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Value = new ValueViewModel();
        }

        public IActionResult OnGet(int? number = null)
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (Value == null || Value.Hours == null || Value.Generation == null && Value.Distribution == null && Value.Transmission == null)
            {
                Value.Message = "Cannot calculate value";
            }
            else
            {
                Value.Consumption = (Value.Wattage = Value.Hours) / 1000;
                Value.Message = "Your Consumption is " + Value.Consumption?.ToString("##.##");

                if (Value.Consumption == 31 || Value.Consumption > 31)
                {
                    Value.Mark = "31-above kWH";
                    Value.Description = "27Php";
                }
                else if (Value.Consumption >= 21 && Value.Consumption <= 30) //21,22,23,24,25,26,27,28,29,30
                {
                    Value.Mark = "21-30kWh";
                    Value.Description = "21Php";
                }
                else if (Value.Consumption >= 11 && Value.Consumption <= 30) //11,12,13,14,15,16,17,18,19,20
                {
                    Value.Mark = "11-20kWh";
                    Value.Description = "15Php";
                }
                else if (Value.Consumption >= 1 && Value.Consumption <= 30) //1,2,3,4,5,6,7,8,9,10
                {
                    Value.Mark = "1-10kWh";
                    Value.Description = "9.00Php";
                }
                if (Value.Consumption == 31 || Value.Consumption > 31)
                {
                    Value.Mark = "31-above kWH";
                    Value.Description = "0.4613Php";


                }
                else if (Value.Consumption >= 16 && Value.Consumption <= 30) //16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
                {
                    Value.Mark = "31-above kWH";
                    Value.Description = "0.3644Php";

                }
                else if (Value.Consumption >= 1 && Value.Consumption <= 15) //1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
                {
                    Value.Mark = "1-15kWh";
                    Value.Description = "0.2389Php";
                }
                if (Value.Consumption == 31 || Value.Consumption > 31)
                {
                    Value.Mark = "31-above kWH";
                    Value.Description = "0.3200";
                }
                else if (Value.Consumption >= 25 && Value.Consumption <= 30) //25,26,27,28,29,30
                {
                    Value.Mark = "25-30kWH";
                    Value.Description = "0.3100Php";
                }
                else if (Value.Consumption >= 19 && Value.Consumption <= 24) //19,20,21,22,23,24
                {
                    Value.Mark = "19-24kWH";
                    Value.Description = "0.2200Php";
                }

                else if (Value.Consumption >= 13 && Value.Consumption <= 18) //13,14,15,16,17,18
                {
                    Value.Mark = "13-24kWH";
                    Value.Description = "0.2110Php";

                }
                else if (Value.Consumption >= 7 && Value.Consumption <= 12) //7,8,9,10,11,12
                {
                    Value.Mark = "7-12kWH";
                    Value.Description = "0.1210Php";
                }
                Value.Consumption = (Value.Hours + Value.Generation + Value.Hours + Value.Distribution + Value.Hours + Value.Transmission);
                Value.Message = "Your Overall Value is " + Value.Consumption?.ToString("##.##");

            }
            return Page();
        }
        public class ValueViewModel
        {
            public decimal? AirConditionUnits { get; set; }

            public decimal? Wattage { get; set; }

            public decimal? Hours { get; set; }

            public decimal? Consumption { get; set; }

            public decimal? Transmission { get; set; }

            public decimal? Distribution { get; set; }

            public decimal? Generation { get; set; }

            public string? Message { get; set; }

            public string? Mark { get; set; }

            public string? Description { get; set; }

        }
    }
}