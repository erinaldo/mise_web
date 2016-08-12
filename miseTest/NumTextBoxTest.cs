using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mise.component;
using System.Windows.Forms;

namespace miseTest
{
    [TestClass]
    public class NumTextBoxTest : NumTextBox
    {
        [TestMethod]
        public void Dec_InitializedWith_0()
        {
            NumTextBox n = new NumTextBox();
            Assert.AreEqual(0, n.Dec);
        }

        [TestMethod]
        public void AutoComma_InitializedWith_false()
        {
            NumTextBox n = new NumTextBox();
            Assert.IsFalse(n.AutoComma);
        }

        private void testOnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        [TestMethod]
        public void OnKeyPress_LettersNotAllowed_a()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('a');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_LettersNotAllowed_x()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('x');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_LettersNotAllowed_j()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('j');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_SpecialCharsNotAllowed_sharp()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('#');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_SpecialCharsNotAllowed_percent()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('%');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_SpecialCharsNotAllowed_at()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();
            KeyPressEventArgs e = new KeyPressEventArgs('@');
            txtBox.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_NumbersAllowed_1()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();

            KeyPressEventArgs e = new KeyPressEventArgs('1');
            txtBox.testOnKeyPress(e);
            Assert.IsFalse(e.Handled);

        }

        [TestMethod]
        public void OnKeyPress_NumbersAllowed_6()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();

            KeyPressEventArgs e = new KeyPressEventArgs('6');
            txtBox.testOnKeyPress(e);
            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_NumbersAllowed_9()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();

            KeyPressEventArgs e = new KeyPressEventArgs('9');
            txtBox.testOnKeyPress(e);
            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_CommaNotAllowed_Dec0()
        {
            NumTextBoxTest txtBox = new NumTextBoxTest();

            KeyPressEventArgs e = new KeyPressEventArgs(',');
            txtBox.testOnKeyPress(e);
            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_CommaNotAllowed_TextAlreadyHasComma()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = "0,1";
            
            KeyPressEventArgs e = new KeyPressEventArgs(',');
            n.testOnKeyPress(e);
            Assert.IsTrue(e.Handled);
        }


        [TestMethod]
        public void OnKeyPress_CommaAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = "20";

            KeyPressEventArgs e = new KeyPressEventArgs(',');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_NumberNotAllowed_DecLimit()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = "0,01";

            KeyPressEventArgs e = new KeyPressEventArgs('1');
            n.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_NumberAllowed_LastPossible()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = "0,0";

            KeyPressEventArgs e = new KeyPressEventArgs('1');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_AutoComma_CommaNotAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.AutoComma = true;
            
            KeyPressEventArgs e = new KeyPressEventArgs(',');
            n.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_AutoComma_NumberAllowed_1()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.AutoComma = true;

            KeyPressEventArgs e = new KeyPressEventArgs('1');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_AutoComma_NumberAllowed_6()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.AutoComma = true;

            KeyPressEventArgs e = new KeyPressEventArgs('2');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_AutoComma_NumberAllowed_9()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.AutoComma = true;

            KeyPressEventArgs e = new KeyPressEventArgs('2');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_EnterAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            KeyPressEventArgs e = new KeyPressEventArgs((char) Keys.Enter);
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_BackspaceAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            KeyPressEventArgs e = new KeyPressEventArgs((char)Keys.Back);
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_CtrlAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            KeyPressEventArgs e = new KeyPressEventArgs((char) Keys.ControlKey);
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_ShiftAllowed()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            KeyPressEventArgs e = new KeyPressEventArgs((char) Keys.ShiftKey);
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_OnKeyPress_Decimal_MaxLengthReached_NoCommaTyped()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.MaxLength = 6;
            n.Text = "123";
            KeyPressEventArgs e = new KeyPressEventArgs('1');
            n.testOnKeyPress(e);

            Assert.IsTrue(e.Handled);
        }

        [TestMethod]
        public void OnKeyPress_OnKeyPress_Decimal_MaxLengthNotReached_NoCommaTyped()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.MaxLength = 6;
            n.Text = "12";
            KeyPressEventArgs e = new KeyPressEventArgs('1');
            n.testOnKeyPress(e);

            Assert.IsFalse(e.Handled);
        }

        // TODO: fazer mais testes do onkeypress maxlength

        private void testOnTextChanged()
        {
            base.OnTextChanged(EventArgs.Empty);
        }

        [TestMethod]
        public void OnTextChanged_Number_DoNothing()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Text = "123";

            n.testOnTextChanged();

            Assert.AreEqual("123", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_CommaAtFirst_AddZero()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = ",";

            n.testOnTextChanged();

            Assert.AreEqual("0,", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_2()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 2;
            n.Text = "1234";

            n.testOnTextChanged();

            Assert.AreEqual("12,34", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_2_LeftZeroes()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 2;
            n.Text = "6";

            n.testOnTextChanged();

            Assert.AreEqual("0,06", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_2_LeftZeroes2()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 2;
            n.Text = "66";

            n.testOnTextChanged();

            Assert.AreEqual("0,66", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_2_RemoveUnnecessaryZeroes()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 2;
            n.Text = "000006";

            n.testOnTextChanged();

            Assert.AreEqual("0,06", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_3()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 3;
            n.Text = "1234";

            n.testOnTextChanged();

            Assert.AreEqual("1,234", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_3_2()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 3;
            n.Text = "123456";

            n.testOnTextChanged();

            Assert.AreEqual("123,456", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_3_LeftZeroes()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 3;
            n.Text = "6";

            n.testOnTextChanged();

            Assert.AreEqual("0,006", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_3_LeftZeroes2()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 3;
            n.Text = "66";

            n.testOnTextChanged();

            Assert.AreEqual("0,066", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_AutoComma_AddComa_3_LeftZeroes3()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.AutoComma = true;
            n.Dec = 3;
            n.Text = "666";

            n.testOnTextChanged();

            Assert.AreEqual("0,666", n.Text);
        }

        [TestMethod]
        public void OnTextChanged_CursorAtLastIndex()
        {
            NumTextBoxTest n = new NumTextBoxTest();
            n.Dec = 2;
            n.Text = "1234";

            n.testOnTextChanged();

            Assert.AreEqual(n.Text.Length, n.SelectionStart);
        }

    }
}
