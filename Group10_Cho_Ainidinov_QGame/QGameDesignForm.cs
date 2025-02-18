//Created by:
//Aleksandr Ainidinov(8905450)
//Seongwon Cho(8965929)

//Date October 27, 2024

//Purpose:
//1. Create a “Q-Puzzle” game using Windows Forms
//2. Create a game level designer
//3. Design a level using the designer
//4. Save the level as a text file
//5. Load the level from a text file
//6. Make sure the Design part is fully working: logic, message boxes etc




//using Group10_Cho_Ainidinov_QGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Group10_Cho_Ainidinov_QGame
{
    /// <summary>
    /// Form of the “Q-Puzzle” game
    /// Allows user to initialize grid, save to and load from a file mazes.
    /// </summary>
    public partial class QGameDesignForm : Form
    {
        // Bool variables for checking if rows and columns were entered before
        private bool isFirstNumberOfRows = true;
        private bool isFirstNumberOfColumns = true;
        private GridType gridType = GridType.Empty;

        // Two-dimensional array for storing grid values
        private GridType[,] gridArray;

        // Dictionary for storing picture boxes
        private Dictionary<(int row, int column), PictureBox> pictureBoxDictionary = new Dictionary<(int row, int column), PictureBox>();

        private Bitmap generateImage;
        private Bitmap exitImage;
        private Bitmap loadImage;
        private Bitmap saveImage;


        private Bitmap noneImage;
        private Bitmap noneImage2;
        private Bitmap wallImage;
        private Bitmap redDoorImage;
        private Bitmap greenDoorImage;
        private Bitmap blueDoorImage;
        private Bitmap redBoxImage;
        private Bitmap greenBoxImage;
        private Bitmap blueBoxImage;



        private const int INIT_LEFT = 200;
        private const int INIT_TOP = 100;
        private const int gridWidth = 40;
        private const int gridHeight = 40;
        private const int verticalGap = 0;
        private const int horizontalGap = 0;
        private int numberOfRows;
        private int numberOfColumns;

        /// <summary>
        /// Enum class for types of grid.
        /// </summary>
        enum GridType
        {
            Empty,
            Wall,
            RedDoor,
            GreenDoor,
            BlueDoor,
            RedBox,
            GreenBox,
            BlueBox
        }

        /// <summary>
        /// Generate Images for the form application.
        /// </summary>
        public QGameDesignForm()
        {
            InitializeComponent();

            using (var ms = new MemoryStream(Resource.game_design_24))
            {
                generateImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.exit_black_24))
            {
                exitImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.open_file_24))
            {
                loadImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.save_file_24))
            {
                saveImage = new Bitmap(ms);
            }


            buttonGenerate.Image = generateImage;
            buttonExit.Image = exitImage;
            buttonLoad.Image = loadImage;
            buttonSave.Image = saveImage;

            using (var ms = new MemoryStream(Resource.square_24))
            {
                noneImage = new Bitmap(ms);
            }

            using (var ms = new MemoryStream(Resource.square_white_1024))
            {
                noneImage2 = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.wall_24))
            {
                wallImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.red_door_24))
            {
                redDoorImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.green_door_24))
            {
                greenDoorImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.blue_door_24))
            {
                blueDoorImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.red_block_24))
            {
                redBoxImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.green_block_24))
            {
                greenBoxImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.blue_block_24))
            {
                blueBoxImage = new Bitmap(ms);
            }

            buttonNone.Image = noneImage;
            buttonWall.Image = wallImage;
            buttonRedDoor.Image = redDoorImage;
            buttonGreenDoor.Image = greenDoorImage;
            buttonBlueDoor.Image = blueDoorImage;
            buttonRedBox.Image = redBoxImage;
            buttonGreenBox.Image = greenBoxImage;
            buttonBlueBox.Image = blueBoxImage;
        }

        /// <summary>
        /// Initializing the Grids out of picture boxes.
        /// </summary>
        /// <param name="numberOfRows">Rows for the new maze</param>
        /// <param name="numberOfColumns">Columns for the new maze</param>
        private void InitializeGrid(int numberOfRows, int numberOfColumns)
        {
            int x = INIT_LEFT;
            int y = INIT_TOP;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Left = x;
                    pictureBox.Top = y;
                    pictureBox.Width = gridWidth;
                    pictureBox.Height = gridHeight;
                    pictureBox.BackColor = Color.White;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.Name = i.ToString() + "," + j.ToString();
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    this.Controls.Add(pictureBox);
                    pictureBoxDictionary[(i, j)] = pictureBox; // Adding a new picture box to the dictionary using its grid position as keys

                    pictureBox.Click += ToolButtonClick; // Calling a function in case user clicks on one of the picture boxes

                    x += gridWidth + horizontalGap;
                }

                x = INIT_LEFT;
                y += gridHeight + verticalGap;
            }
        }
        /// <summary>
        /// Allows to get all controls to the List, removing them from the collection and dispose them.
        /// </summary>

        private void RemovePictureBoxes()
        {
            //Collects List of controls
            List<Control> pictureBoxes = new List<Control>();
            foreach (Control control in Controls)
            {
                if (control is PictureBox)
                {
                    pictureBoxes.Add(control); // Adding picture boxes
                }
            }

            foreach (Control pictureBox in pictureBoxes)
            {
                Controls.Remove(pictureBox); // Remove controls
                pictureBox.Dispose();        // Disposing properly
            }
        }

        /// <summary>
        /// Event that activates when the selected index for Rows was changed.
        /// Asks user if they want to abandon current level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectRowSize = comboBox1.SelectedIndex.ToString();
            int newNumberOfRows = Convert.ToInt32(comboBoxRows.SelectedItem);

            // Checking if it's the first input of rows
            if (isFirstNumberOfRows)
            {
                numberOfRows = newNumberOfRows;
                isFirstNumberOfRows = false;
                return;
            }
            // Asking the user if they want to abandon this level
            else
            {
                DialogResult result = MessageBox.Show("Do you want to abandon the current level and start a new one?", "Abandoning current level", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    numberOfRows = newNumberOfRows;
                    RemovePictureBoxes();
                    InitializeGrid(numberOfRows, numberOfColumns);
                }
            }
        }

        /// <summary>
        /// Event that activates when the selected index for Columns was changed.
        /// Asks user if they want to abandon current level.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newNumberOfColumns = Convert.ToInt32(comboBoxColumns.SelectedItem);

            // Checking if it's the first input of columns
            if (isFirstNumberOfColumns)
            {
                numberOfColumns = newNumberOfColumns;
                isFirstNumberOfColumns = false;
                return;
            }
            // Asking the user if they want to abandon this level
            else
            {
                DialogResult result = MessageBox.Show("Do you want to abandon the current level and start a new one?", "Abandoning current level", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    numberOfColumns = newNumberOfColumns;
                    RemovePictureBoxes();
                    InitializeGrid(numberOfRows, numberOfColumns);
                }
            }
        }

        /// <summary>
        /// Generates the grid using number of rows and columns selected by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            numberOfRows = Convert.ToInt32(comboBoxRows.SelectedItem);
            numberOfColumns = Convert.ToInt32(comboBoxColumns.SelectedItem);
            InitializeGrid(numberOfRows, numberOfColumns);
            gridArray = new GridType[numberOfRows, numberOfColumns];
        }

        // Changing grid type variable depending on the selected item in the tool box
        private void buttonNone_Click(object sender, EventArgs e)
        {
            gridType = GridType.Empty;
        }

        private void buttonWall_Click(object sender, EventArgs e)
        {
            gridType = GridType.Wall;
        }

        private void buttonBlueBox_Click(object sender, EventArgs e)
        {
            gridType = GridType.BlueBox;
        }

        private void buttonGreenBox_Click(object sender, EventArgs e)
        {
            gridType = GridType.GreenBox;
        }

        private void buttonRedBox_Click(object sender, EventArgs e)
        {
            gridType = GridType.RedBox;
        }
        private void buttonRedDoor_Click(object sender, EventArgs e)
        {
            gridType = GridType.RedDoor;
        }

        private void buttonGreenDoor_Click(object sender, EventArgs e)
        {
            gridType = GridType.GreenDoor;
        }

        private void buttonBlueDoor_Click(object sender, EventArgs e)
        {
            gridType = GridType.BlueDoor;
        }

        /// <summary>
        /// Adds a picture to the selected cell in the grid according to the grid type it has.
        /// Updates the grid array.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButtonClick(object sender, EventArgs e)
        {
            PictureBox gridCellClicked = sender as PictureBox;

            if (gridCellClicked != null)
            {
                // Getting row and column of the clicked cell from its name
                string rowClicked = gridCellClicked.Name.Split(',')[0];
                string columnClicked = gridCellClicked.Name.Split(",")[1];

                gridArray[Int32.Parse(rowClicked), Int32.Parse(columnClicked)] = gridType; // Assigning grid type to a needed cell in the array

                if (gridType == GridType.Empty)
                {
                    gridCellClicked.Image = noneImage2;
                }
                else if (gridType == GridType.Wall)
                {
                    gridCellClicked.Image = wallImage;
                }
                else if (gridType == GridType.RedDoor)
                {
                    gridCellClicked.Image = redDoorImage;
                }
                else if (gridType == GridType.BlueDoor)
                {
                    gridCellClicked.Image = blueDoorImage;
                }
                else if (gridType == GridType.GreenDoor)
                {
                    gridCellClicked.Image = greenDoorImage;
                }
                else if (gridType == GridType.RedBox)
                {
                    gridCellClicked.Image = redBoxImage;
                }
                else if (gridType == GridType.BlueBox)
                {
                    gridCellClicked.Image = blueBoxImage;
                }
                else if (gridType == GridType.GreenBox)
                {
                    gridCellClicked.Image = greenBoxImage;
                }
            }
        }

        /// <summary>
        /// Writes the grid and its elements to the txt file.
        /// </summary>
        private void SaveGridToTxt()
        {
            // File Dialog for saving the file to the computer
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Saving Maze to a Text File";
                saveFileDialog.Filter = "Text Files (*.txt) | *.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine($"{numberOfRows}, {numberOfColumns}");

                        // Counters for doors, boxes and walls
                        int doorCount = 0;
                        int boxCount = 0;
                        int wallCount = 0;

                        for (int i = 0; i < numberOfRows; i++)
                        {
                            for (int j = 0; j < numberOfColumns; j++)
                            {
                                string elementToSave = GridElementParse(i, j, ref doorCount, ref boxCount, ref wallCount);
                                writer.Write(elementToSave + "|"); // Writing to a file
                            }
                            writer.WriteLine();
                        }
                        MessageBox.Show($"Grid was saved successfully!\n Doors: {doorCount}, Boxes: {boxCount}, Walls: {wallCount}", "Confirmation of Save Message", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// Parses needed grid element so it can be written to the txt file.
        /// Count the number of walls, doors and boxes.
        /// </summary>
        /// <param name="row">Row of needed element</param>
        /// <param name="column">Column of needed element</param>
        /// <param name="doorCount">Number of Doors</param>
        /// <param name="boxCount">Number of Boxes</param>
        /// <param name="wallCount">Number of Walls</param>
        /// <returns>String representation of the grid type</returns>
        /// <exception cref="ArgumentOutOfRangeException">Unknown grid type error</exception>
        private string GridElementParse(int row, int column, ref int doorCount, ref int boxCount, ref int wallCount)
        {
            GridType element = gridArray[row, column];

            // Going through all the grid types and returning needed string representation of it
            if (element == GridType.Empty)
            {
                return "Empty";
            }

            else if (element == GridType.Wall)
            {
                wallCount++;
                return "Wall";
            }

            else if (element == GridType.RedDoor)
            {
                doorCount++;
                return "RedDoor";
            }
            else if (element == GridType.BlueDoor)
            {
                doorCount++;
                return "BlueDoor";
            }
            else if (element == GridType.GreenDoor)
            {
                doorCount++;
                return "GreenDoor";
            }
            else if (element == GridType.RedBox)
            {
                boxCount++;
                return "RedBox";
            }
            else if (element == GridType.BlueBox)
            {
                boxCount++;
                return "BlueBox";
            }
            else if (element == GridType.GreenBox)
            {
                boxCount++;
                return "GreenBox";
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(element), "Unknown Grid Type");
            }
        }

        /// <summary>
        /// Loads the grid and its elements from the txt file.
        /// </summary>
        private void LoadGridFromTxt()
        {
            // File Dialog for loading a file from the computer
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Loading Maze from a Text File";
                openFileDialog.Filter = "Text Files (*.txt) | *.txt";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(openFileDialog.FileName))
                    {
                        MessageBox.Show("This File Doesn't Exist!", "Not existing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string[] gridSize = reader.ReadLine().Split(", ");

                        int numberOfRows = Int32.Parse(gridSize[0]);
                        int numberOfColumns = Int32.Parse(gridSize[1]);

                        // Initializing a new array with rows and columns from the file
                        gridArray = new GridType[numberOfRows, numberOfColumns];

                        RemovePictureBoxes();
                        InitializeGrid(numberOfRows, numberOfColumns); // Initializing empty grid

                        for (int i = 0; i < numberOfRows; i++)
                        {
                            string line = reader.ReadLine();
                            string[] elements = line.Split("|"); // Getting a line from the file and splitting it by the separator

                            for (int j = 0; j < numberOfColumns; j++)
                            {
                                gridArray[i, j] = GridElementSerialize(elements[j]);
                                UpdateImages(i, j, gridArray[i, j]);
                            }
                        }
                        MessageBox.Show($"Grid was loaded successfully!", "Confirmation of Load Message", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// Converts grid element from a string to a needed grid type in enum.
        /// </summary>
        /// <param name="element">String representation of a grid type.</param>
        /// <returns>Grid type respective to the given string representation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Unknown grid type error</exception>
        private GridType GridElementSerialize(string element)
        {
            // Going through all the string representations and returning needed grid type for it
            if (element == "Empty")
            {
                return GridType.Empty;
            }

            else if (element == "Wall")
            {
                return GridType.Wall;
            }

            else if (element == "RedDoor")
            {
                return GridType.RedDoor;
            }
            else if (element == "BlueDoor")
            {
                return GridType.BlueDoor;
            }
            else if (element == "GreenDoor")
            {
                return GridType.GreenDoor;
            }
            else if (element == "RedBox")
            {
                return GridType.RedBox;
            }
            else if (element == "BlueBox")
            {
                return GridType.BlueBox;
            }
            else if (element == "GreenBox")
            {
                return GridType.GreenBox;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(element), "Unknown Grid Type");
            }
        }

        /// <summary>
        /// Updates images for the picture boxes in the initialized grid from the txt file.
        /// </summary>
        /// <param name="numberOfRows">Row of the picture box which image to change.</param>
        /// <param name="numberOfColumns">Column of the picture box which image to change.</param>
        /// <param name="gridType">Type of grid element that defines what image to put instead.</param>
        /// <exception cref="ArgumentOutOfRangeException">Unknown grid type error</exception>
        private void UpdateImages(int numberOfRows, int numberOfColumns, GridType gridType)
        {
            PictureBox pictureBoxToUpdate = pictureBoxDictionary[(numberOfRows, numberOfColumns)];

            // Going through all the grid types and changing the image to a needed one
            if (gridType == GridType.Empty)
            {
                pictureBoxToUpdate.Image = noneImage2;
            }
            else if (gridType == GridType.Wall)
            {
                pictureBoxToUpdate.Image = wallImage;
            }
            else if (gridType == GridType.RedDoor)
            {
                pictureBoxToUpdate.Image = redDoorImage;
            }
            else if (gridType == GridType.BlueDoor)
            {
                pictureBoxToUpdate.Image = blueDoorImage;
            }
            else if (gridType == GridType.GreenDoor)
            {
                pictureBoxToUpdate.Image = greenDoorImage;
            }
            else if (gridType == GridType.RedBox)
            {
                pictureBoxToUpdate.Image = redBoxImage;
            }
            else if (gridType == GridType.BlueBox)
            {
                pictureBoxToUpdate.Image = blueBoxImage;
            }
            else if (gridType == GridType.GreenBox)
            {
                pictureBoxToUpdate.Image = greenBoxImage;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(gridType), "Unknown Grid Type");
            }
        }

        /// <summary>
        /// Saving event that uses existing method to save the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveGridToTxt();
        }

        /// <summary>
        /// Loading event that uses existing method to load the maze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadGridFromTxt();
        }

        /// <summary>
        /// Exiting event that goes back to the control panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color darkBlue = Color.DarkBlue;
            Color lightBlue = Color.LightBlue;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                darkBlue,
                lightBlue,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Color darkRed = Color.DarkRed;
            Color lightBlue = Color.LightBlue;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                darkRed,
                lightBlue,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void QGameDesignForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

    }
}
