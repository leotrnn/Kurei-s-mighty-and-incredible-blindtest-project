using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KureiBlindTest
{
    public class NavigationService
    {
        private Stack<Form> formStack = new Stack<Form>();
        private Form currentForm;

        public NavigationService(Form homeForm)
        {
            currentForm = homeForm;
        }

        public NavigationService()
        {
            
        }

        public void NavigateTo(Form newForm)
        {
            if (currentForm is frmHome)
            {
                currentForm.Hide();
            }
            if (currentForm != null && !(currentForm is frmHome))
            {
                formStack.Push(currentForm);
                currentForm.Hide();
            }

            newForm.StartPosition = FormStartPosition.CenterScreen;
            currentForm = newForm;
            currentForm.Show();
        }

        public void NavigateBack()
        {
            if (formStack.Count > 0)
            {
                currentForm.Close();
                currentForm = formStack.Pop();
                currentForm.Show();
            }
        }

        public void ResetToHome()
        {
            while (formStack.Count > 0)
            {
                formStack.Pop().Close();
            }

            if (currentForm != null && !(currentForm is frmHome))
            {
                currentForm.Hide();

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is frmHome)
                    {
                        openForm.Show();
                        currentForm = openForm;
                        break;
                    }
                }
            }
        }
    }
}
