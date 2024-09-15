namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private String expression = "";
        private String currentOperator = "";
        private String display = "0";
        private bool nextNumber = false; // Whether the next number should be appended to the display or replace it

        public MainPage()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            expressionDisplay.Text = $"{expression} {currentOperator}";
            currentDisplay.Text = display;
        }
        private String Calculate()
        {
            Double a = expression == "" ? 0.0 : Double.Parse(expression);
            Double b = Double.Parse(display);
            String result = "";

            switch (currentOperator)
            {
                case "+":
                    result = (a + b).ToString();
                    break;
                case "–":
                    result = (a - b).ToString();
                    break;
                case "×":
                    result = (a * b).ToString();
                    break;
                case "÷":
                    if (b == 0)
                        result = "Error: Divide By Zero";
                    else
                        result = (a / b).ToString();
                    break;
                default:
                    result = display;
                    break;
            }

            return result;
        }
        private void OnPercentClicked(object sender, EventArgs e)
        {
            display = (Double.Parse(display) / 100).ToString();
            nextNumber = true;
            update();
        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            display = "0";
            nextNumber = false;
            update();

        }
        private void OnResetClicked(object sender, EventArgs e)
        {
            expression = "";
            currentOperator = "";
            display = "0";
            nextNumber = false;
            update();
        }
        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (display.Length == 1 || (display.Length == 2 && display.ElementAt<char>(0) == '-'))
                display = "0";
            else
                display = display.Substring(0, display.Length - 1);

            if (display.ElementAt<char>(display.Length - 1) == '.')
                display = display.Substring(0, display.Length - 1);

            update();
        }
        private void OnReciprocalClicked(object sender, EventArgs e)
        {
            display = (1 / Double.Parse(display)).ToString();
            nextNumber = true;
            update();
        }
        private void OnSquareClicked(object sender, EventArgs e)
        {
            display = (Double.Parse(display) * Double.Parse(display)).ToString();
            nextNumber = true;
            update();
        }
        private void OnSquareRootClicked(object sender, EventArgs e)
        {
            display = Math.Sqrt(Double.Parse(display)).ToString();
            nextNumber = true;
            update();
        }
        private void OnPosNegToggleClicked(object sender, EventArgs e)
        {
            if (display.ElementAt<char>(0) == '-')
                display = display.Substring(1, display.Length - 1);
            else
                display = "-" + display;

            update();
        }
        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (expression == "")
            {
                expression = display;
                currentOperator = ((Button)sender).Text;
            }
            else
            {
                expression = Calculate();
                currentOperator = ((Button)sender).Text;
            }
            nextNumber = true;
            update();
        }
        private void OnNumberClicked(object sender, EventArgs e)
        {
            String text = ((Button)sender).Text;

            if (text == "." && display.Contains('.'))
                return;

            if (display == "0" || nextNumber)
            {
                if (text == ".")
                    display += text;
                else
                    display = text;

                nextNumber = false;
            }
            else
                display += text;

            update();
        }
        private void OnEqualsClicked(object sender, EventArgs e)
        {
            String result = Calculate();
            expressionDisplay.Text = $"{expression} {currentOperator} {display} =";
            currentDisplay.Text = result;
            display = result;

            expression = "";
            currentOperator = "";
            nextNumber = true;
        }

    }

}
