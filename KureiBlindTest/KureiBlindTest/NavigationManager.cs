using System;
using System.Collections.Generic;
using System.Windows.Forms;

public static class NavigationManager
{
    private static Stack<Form> formStack = new Stack<Form>();

    public static void OpenForm(Form form, Form parentForm = null)
    {
        if (parentForm != null)
        {
            parentForm.Hide();
            form.StartPosition = FormStartPosition.CenterParent;
        }

        formStack.Push(form);

        form.FormClosed += (s, args) =>
        {
            formStack.Pop();
            if (formStack.Count > 0)
            {
                Form previousForm = formStack.Peek();
                previousForm.Show();
            }
            else
            {
                Application.Exit();
            }
        };

        form.Show();
    }

    public static void ExitApplication()
    {
        formStack.Clear();
        Application.Exit();
    }
}
