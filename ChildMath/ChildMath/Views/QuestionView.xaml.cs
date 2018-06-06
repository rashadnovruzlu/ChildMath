using ChildMath.Helper;
using ChildMath.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChildMath.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionView : ContentPage
    {
        Random _random = new Random();

        List<Question> _questionList = new List<Question>();

        int[] _mathOperationSequence = new int[QuestionType.QuestionCount];

        int _floor;

        int _currentQuestionCount = 0;

        public QuestionView()
        {

            InitializeComponent();

            _floor = GetFloorMaxValue(QuestionType.Floor);

            GenerateMathOperations();

            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int number1, number2;
            number1 = _random.Next(1, _floor);
            number2 = _random.Next(1, _floor);

            Question model = new Question();
            model.Number1 = number1 > number2 ? number1 : number2;
            model.Number2 = number1 > number2 ? number2 : number1;
            model.MathOperations = _mathOperationSequence[_currentQuestionCount];
            model.Result = Calculation(model.Number1, model.Number2, model.MathOperations);
            model.Answer = 0;

            _questionList.Add(model);

            _currentQuestionCount++;

            lblNumber1.Text = model.Number1.ToString();
            lblNumber2.Text = model.Number2.ToString();
            lblSymbols.Text = GetMathOperationsSymbol(model.MathOperations);

        }


        private async Task btnNext_ClickedAsync(object sender, EventArgs e)
        {
            if (_currentQuestionCount == _mathOperationSequence.Length - 1)
            {
                await DisplayAlert(null, "Oyun başa çatdı", "Yenidən başla");
                await Navigation.PushModalAsync(new ChooseQuestionType());
            }
            lblAnswer.Text = "= " + _questionList.Last().Result.ToString();
            await Task.Delay(2000);
            GenerateQuestion();
            lblAnswer.Text = "= ?";
        }


        private void GenerateMathOperations()
        {
            int mathOperationCount = 0;
            int arrayIndex = 0;

            if (QuestionType.Addition) mathOperationCount++;
            if (QuestionType.Subtraction) mathOperationCount++;
            if (QuestionType.Multiplication) mathOperationCount++;
            if (QuestionType.Division) mathOperationCount++;

            for (int i = 0; i < QuestionType.QuestionCount % mathOperationCount; i++)
            {
                if (QuestionType.Addition) _mathOperationSequence[arrayIndex] = (int)MathOperations.Addition;
                else if (QuestionType.Subtraction) _mathOperationSequence[arrayIndex] = (int)MathOperations.Subtraction;
                else if (QuestionType.Multiplication) _mathOperationSequence[arrayIndex] = (int)MathOperations.Multiplication;
                else _mathOperationSequence[arrayIndex] = (int)MathOperations.Division;
                arrayIndex++;
            }

            while (arrayIndex < _mathOperationSequence.Length)
            {
                if (QuestionType.Addition)
                {
                    _mathOperationSequence[arrayIndex] = (int)MathOperations.Addition;
                    arrayIndex++;
                }
                if (QuestionType.Subtraction)
                {
                    _mathOperationSequence[arrayIndex] = (int)MathOperations.Subtraction;
                    arrayIndex++;
                }
                if (QuestionType.Multiplication)
                {
                    _mathOperationSequence[arrayIndex] = (int)MathOperations.Multiplication;
                    arrayIndex++;
                }
                if (QuestionType.Division)
                {
                    _mathOperationSequence[arrayIndex] = (int)MathOperations.Division;
                    arrayIndex++;
                }
            }
        }

        private static int Calculation(int number1, int number2, int mathOperations)
        {
            int result = 0;

            switch (mathOperations)
            {
                case (int)MathOperations.Addition:
                    result = number1 + number2;
                    break;
                case (int)MathOperations.Subtraction:
                    result = number1 - number2;
                    break;
                case (int)MathOperations.Multiplication:
                    result = number1 * number2;
                    break;
                case (int)MathOperations.Division:
                    result = number1 / number2;
                    break;
            }

            return result;
        }

        private static int GetFloorMaxValue(int value)
        {
            int result = 0;

            switch (value)
            {
                case 1:
                    result = 9;
                    break;
                case 2:
                    result = 99;
                    break;
                case 3:
                    result = 999;
                    break;
                default:
                    result = 9999;
                    break;
            }

            return result;
        }

        private string GetMathOperationsSymbol(int mathOperations)
        {
            string result = string.Empty;

            switch (mathOperations)
            {
                case (int)MathOperations.Addition:
                    result = "+";
                    break;
                case (int)MathOperations.Subtraction:
                    result = "-";
                    break;
                case (int)MathOperations.Multiplication:
                    result = "*";
                    break;
                case (int)MathOperations.Division:
                    result = "/";
                    break;
            }

            return result;
        }



    }
}