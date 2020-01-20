using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParserCalculator;

namespace WebApplication_Calculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calculate_Click(object sender, EventArgs e)
        {
            string result = "";
            try
            {
                result = Parser.Start(ExpressionField.Text).ToString();
            }
            catch
            {
                result = "Некорректное выражение";
            }
            finally
            {
                Output.Text = result;
            }
        }
    }
}