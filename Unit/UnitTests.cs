using System.Reflection;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using The_Stoic_Way;

namespace Unit
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestWorkButton_Click_ValidInput()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var workTimeField = typeof(TheStoicWay).GetField("WorkTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerField = typeof(TheStoicWay).GetField("workTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            var workTimeInputField = typeof(TheStoicWay).GetField("workTimeInput", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimeInputValue = workTimeInputField.GetValue(stoicWayForm);

            // Set the values of WorkTime and RestTime controlss
            var workTimeControl = (MaskedTextBox)workTimeField.GetValue(stoicWayForm);
            workTimeControl.Text = "00:05:00"; // Set valid work time input

            var restTimeControl = (MaskedTextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:02:00"; // Set valid rest time input

            // Invoke the private WorkButton_Click method
            var methodInfo = typeof(TheStoicWay).GetMethod("WorkButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.AreEqual("00:05:00", workTimeControl.Text);
            Assert.AreEqual("00:05:00", workTimeInputValue);
            Assert.IsTrue(((Timer)workTimerField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestWorkButton_Click_InvalidInput()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var workTimeField = typeof(TheStoicWay).GetField("WorkTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerField = typeof(TheStoicWay).GetField("workTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            var workTimeInputField = typeof(TheStoicWay).GetField("workTimeInput", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimeInputValue = workTimeInputField.GetValue(stoicWayForm);

            // Set the values of WorkTime and RestTime controlss
            var workTimeControl = (MaskedTextBox)workTimeField.GetValue(stoicWayForm);
            workTimeControl.Text = "00:05:"; // Set valid work time input

            var restTimeControl = (MaskedTextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:15:00"; // Set valid rest time input

            // Invoke the private WorkButton_Click method
            var methodInfo = typeof(TheStoicWay).GetMethod("WorkButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.AreEqual("00:05:00", workTimeControl.Text);
            Assert.AreEqual("00:05:00", workTimeInputValue);
            Assert.IsTrue(((Timer)workTimerField.GetValue(stoicWayForm)).Enabled);
        }

        public void TestRestButton_Click_ValidInput()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restButtonField = typeof(TheStoicWay).GetField("RestButton", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set a valid rest time input
            var restTimeControl = (TextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:05:00";

            // Act
            var restButtonClickMethod = typeof(TheStoicWay).GetMethod("RestButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            restButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsFalse(((Button)restButtonField.GetValue(stoicWayForm)).Enabled);

        }

        public void TestRestButton_Click_InvalidInput()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restButtonField = typeof(TheStoicWay).GetField("RestButton", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set an invalid rest time input
            var restTimeControl = (TextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:99:0"; // Invalid format, missing seconds

            // Act
            var restButtonClickMethod = typeof(TheStoicWay).GetMethod("RestButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            restButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsFalse(((Button)restButtonField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestWorkTimer_Tick_TimerNotExpired()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields and properties
            var workTimeField = typeof(TheStoicWay).GetField("WorkTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerValueField = typeof(TheStoicWay).GetField("WorkTimerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the values of WorkTime and WorkTimerValue using reflection
            var workTimeControl = (TextBox)workTimeField.GetValue(stoicWayForm);
            workTimeControl.Text = "00:01:00"; // Set work time to 1 minute

            var workTimerValue = TimeSpan.FromSeconds(60);
            workTimerValueField.SetValue(stoicWayForm, workTimerValue);

            // Act
            var workTimerTickMethod = typeof(TheStoicWay).GetMethod("WorkTimer_Tick", BindingFlags.NonPublic | BindingFlags.Instance);
            workTimerTickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.AreEqual("00:00:59", workTimeControl.Text);
            Assert.IsTrue(((Timer)workTimerValueField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestWorkTimer_Tick_TimerExpired()
        {
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var workTimeField = typeof(TheStoicWay).GetField("WorkTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerValueField = typeof(TheStoicWay).GetField("WorkTimerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the initial values using reflection
            var workTimeControl = (TextBox)workTimeField.GetValue(stoicWayForm);
            workTimeControl.Text = "00:01:00"; // Set work time to 1 minute

            var workTimerValue = TimeSpan.FromSeconds(1); // Set a short timer duration for testing
            workTimerValueField.SetValue(stoicWayForm, workTimerValue);

            // Act
            var workTimerTickMethod = typeof(TheStoicWay).GetMethod("WorkTimer_Tick", BindingFlags.NonPublic | BindingFlags.Instance);

            // Trigger the tick event to simulate the timer expiration
            workTimerTickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.AreEqual("00:00:00", workTimeControl.Text);

        }

        [TestMethod]
        public void TestRestTimer_Tick_TimerExpired()
        {
            var stoicWayForm = new TheStoicWay();
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimerValueField = typeof(TheStoicWay).GetField("RestTimerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            var restTimeControl = (TextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:01:00";
            var restTimerValue = TimeSpan.FromSeconds(1);
            restTimerValueField.SetValue(stoicWayForm, restTimerValue);

            var restTimerTickMethod = typeof(TheStoicWay).GetMethod("RestTimer_Tick", BindingFlags.NonPublic | BindingFlags.Instance);
            restTimerTickMethod.Invoke(stoicWayForm, new object[] { null, null });

            Assert.AreEqual("00:00:00", restTimeControl.Text);
            Assert.IsFalse(((Timer)restTimerValueField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestRestTimer_Tick_TimerNotExpired()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimerValueField = typeof(TheStoicWay).GetField("RestTimerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the initial values using reflection
            var restTimeControl = (TextBox)restTimeField.GetValue(stoicWayForm);
            restTimeControl.Text = "00:01:00"; // Set rest time to 1 minute

            var restTimerValue = TimeSpan.FromSeconds(10); // Set a longer timer duration for testing
            restTimerValueField.SetValue(stoicWayForm, restTimerValue);

            // Act
            var restTimerTickMethod = typeof(TheStoicWay).GetMethod("RestTimer_Tick", BindingFlags.NonPublic | BindingFlags.Instance);

            // Trigger the tick event to simulate a partial time elapsed
            restTimerTickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.AreNotEqual("00:00:00", restTimeControl.Text);
            Assert.IsTrue(restTimeControl.Enabled);
            // Add additional assertions based on the expected behavior when the rest timer is not expired
        }

        [TestMethod]
        public void TestPauseButton_Click_WorkTimerEnabled()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields and properties
            var activeTimerField = typeof(TheStoicWay).GetField("activeTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            var workButtonField = typeof(TheStoicWay).GetField("WorkButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerField = typeof(TheStoicWay).GetField("WorkTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the values of activeTimer and enable WorkTimer using reflection
            activeTimerField.SetValue(stoicWayForm, "Work");
            ((Timer)workTimerField.GetValue(stoicWayForm)).Enabled = true;

            // Enable WorkButton using reflection
            ((Button)workButtonField.GetValue(stoicWayForm)).Enabled = true;

            // Act
            var pauseButtonClickMethod = typeof(TheStoicWay).GetMethod("PauseButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            pauseButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsFalse(((Button)workButtonField.GetValue(stoicWayForm)).Enabled);
            Assert.IsFalse(((Timer)workTimerField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestPauseButton_Click_RestTimerEnabled()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var pauseButtonField = typeof(TheStoicWay).GetField("PauseButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimerField = typeof(TheStoicWay).GetField("RestTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the initial values using reflection
            var pauseButtonControl = (Button)pauseButtonField.GetValue(stoicWayForm);
            var restTimerControl = (Timer)restTimerField.GetValue(stoicWayForm);
            pauseButtonControl.Enabled = true;
            restTimerControl.Enabled = true;

            // Act
            var pauseButtonClickMethod = typeof(TheStoicWay).GetMethod("PauseButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            pauseButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsFalse(pauseButtonControl.Enabled);
            Assert.IsFalse(restTimerControl.Enabled);
            // Add additional assertions based on the expected behavior when the pause button is clicked and the rest timer is enabled
        }

        [TestMethod]
        public void TestResumeButton_Click_WorkTimerNotEnabled()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var activeTimerField = typeof(TheStoicWay).GetField("activeTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerField = typeof(TheStoicWay).GetField("WorkTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the values of activeTimer and disable WorkTimer using reflection
            activeTimerField.SetValue(stoicWayForm, "Work");
            ((Timer)workTimerField.GetValue(stoicWayForm)).Enabled = false;

            // Act
            var resumeButtonClickMethod = typeof(TheStoicWay).GetMethod("ResumeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            resumeButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsTrue(((Timer)workTimerField.GetValue(stoicWayForm)).Enabled);
        }

        [TestMethod]
        public void TestResumeButton_Click_WorkTimerEnabled()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var resumeButtonField = typeof(TheStoicWay).GetField("ResumeButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimerField = typeof(TheStoicWay).GetField("WorkTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the initial values using reflection
            var resumeButtonControl = (Button)resumeButtonField.GetValue(stoicWayForm);
            var workTimerControl = (Timer)workTimerField.GetValue(stoicWayForm);
            resumeButtonControl.Enabled = true;
            workTimerControl.Enabled = false; // Simulate the scenario where the work timer is enabled

            // Act
            var resumeButtonClickMethod = typeof(TheStoicWay).GetMethod("ResumeButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            resumeButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsTrue(resumeButtonControl.Enabled);
            Assert.IsTrue(workTimerControl.Enabled);
        }

        [TestMethod]
        public void TestResetButton_Click()
        {
            // Arrange
            var stoicWayForm = new TheStoicWay();

            // Use reflection to access private fields
            var workButtonField = typeof(TheStoicWay).GetField("WorkButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var resumeButtonField = typeof(TheStoicWay).GetField("ResumeButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var pauseButtonField = typeof(TheStoicWay).GetField("PauseButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var resetButtonField = typeof(TheStoicWay).GetField("ResetButton", BindingFlags.NonPublic | BindingFlags.Instance);
            var workTimeField = typeof(TheStoicWay).GetField("WorkTime", BindingFlags.NonPublic | BindingFlags.Instance);
            var restTimeField = typeof(TheStoicWay).GetField("RestTime", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            var resetButtonClickMethod = typeof(TheStoicWay).GetMethod("ResetButton_Click", BindingFlags.NonPublic | BindingFlags.Instance);
            resetButtonClickMethod.Invoke(stoicWayForm, new object[] { null, null });

            // Assert
            Assert.IsTrue(((Button)workButtonField.GetValue(stoicWayForm)).Enabled);
            Assert.IsTrue(((Button)resumeButtonField.GetValue(stoicWayForm)).Enabled);
            Assert.IsTrue(((Button)pauseButtonField.GetValue(stoicWayForm)).Enabled);
            Assert.IsTrue(((Button)resetButtonField.GetValue(stoicWayForm)).Enabled);
            Assert.IsTrue(((TextBox)workTimeField.GetValue(stoicWayForm)).Enabled);
            Assert.IsTrue(((TextBox)restTimeField.GetValue(stoicWayForm)).Enabled);
            Assert.AreEqual("00:00:00", ((TextBox)workTimeField.GetValue(stoicWayForm)).Text);
            Assert.AreEqual("00:00:00", ((TextBox)restTimeField.GetValue(stoicWayForm)).Text);
        }
    }
}