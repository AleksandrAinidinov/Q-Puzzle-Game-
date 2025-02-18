//using Group10_Cho_Ainidinov_QGame.Properties;
using System.Drawing.Text;

namespace Group10_Cho_Ainidinov_QGame
{

    public partial class Group10_Cho_Ainidinov_QGame : Form
    {
        private Bitmap exitImage;
        private Bitmap playImage;
        private Bitmap designImage;

        /// <summary>
        /// Generate Images for form.
        /// </summary>
        public Group10_Cho_Ainidinov_QGame()
        {
            InitializeComponent();

            using (var ms = new MemoryStream(Resource.exit_black_24))
            {
                exitImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.game_play_24))
            {
                playImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.game_design_24))
            {
                designImage = new Bitmap(ms);
            }
            buttonDesign.Image = designImage;
            buttonExit.Image = exitImage;
            buttonPlay.Image = playImage;
        }
        /// <summary>
        /// Button event that opens a Design Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDesign_Click(object sender, EventArgs e)
        {
            QGameDesignForm designForm = new QGameDesignForm();
            designForm.ShowDialog(); //Opens Design Form
        }

        /// <summary>
        /// Button event that exits the form app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            QGamePlayForm playForm = new QGamePlayForm();
            playForm.ShowDialog();
        }
    }
}
