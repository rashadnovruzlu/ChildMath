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
    public partial class ChooseQuestionType : ContentPage
    {
        public ChooseQuestionType()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            pcQuestionCount.SelectedIndex = 1;
            pcFloor.SelectedIndex = 0;
        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            int questionCount, floor;
            questionCount = Convert.ToInt32(pcQuestionCount.Items[pcQuestionCount.SelectedIndex]);
            floor = pcFloor.SelectedIndex + 1;

            QuestionType.Addition = swaddition.IsToggled == true ? true : false;
            QuestionType.Division = swDivision.IsToggled == true ? true : false;
            QuestionType.Multiplication = swMultiplication.IsToggled == true ? true : false;
            QuestionType.Subtraction = swSubtraction.IsToggled == true ? true : false;
            QuestionType.QuestionCount = questionCount;
            QuestionType.Floor = floor;

            Navigation.PushModalAsync(new QuestionView());
        }


    }
}