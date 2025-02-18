//Created by:
//Aleksandr Ainidinov(8905450)
//Seongwon Cho(8965929)

//Date November 24, 2024

//Purpose:
//1. Create a “Q-Puzzle” game using Windows Forms
//2. Create a game level designer
//3. Be able to play a level
//5. Load the level from a text file
//6. Make sure the Playing part is fully working: logic, message boxes etc.




//using Group10_Cho_Ainidinov_QGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group10_Cho_Ainidinov_QGame
{
    /// <summary>
    /// Playing Form of the “Q-Puzzle” game
    /// Allows user to load a maze from a file and play the game.
    /// </summary>
    public partial class QGamePlayForm : Form
    {
        private (int X, int Y) selectedBox;
        private GridType gridType = GridType.Empty;
        // Two-dimensional array for storing cell objects
        private Cell[,] gridCells;

        // Dictionary for storing picture boxes
        private Dictionary<(int row, int column), PictureBox> pictureBoxDictionary = new Dictionary<(int row, int column), PictureBox>();

        private Bitmap loadImage;
        private Bitmap upImage;
        private Bitmap downImage;
        private Bitmap leftImage;
        private Bitmap rightImage;

        private Bitmap noneImage;
        private Bitmap noneImage2;
        private Bitmap wallImage;
        private Bitmap redDoorImage;
        private Bitmap greenDoorImage;
        private Bitmap blueDoorImage;
        private Bitmap redBoxImage;
        private Bitmap greenBoxImage;
        private Bitmap blueBoxImage;

        private Bitmap blueBoxSelectedImage;
        private Bitmap redBoxSelectedImage;
        private Bitmap greenBoxSelectedImage;

        private int movesCount = 0;
        private int boxesRemainingCount = 0;

        private const int INIT_LEFT = 50;
        private const int INIT_TOP = 20;
        private const int gridWidth = 40;
        private const int gridHeight = 40;
        private const int verticalGap = 0;
        private const int horizontalGap = 0;

        /// <summary>
        /// Enum class for types of grid.
        /// </summary>
        public enum GridType
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
        /// Cell class
        /// </summary>
        public class Cell
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public bool IsSelected { get; set; }
            public GridType GridType { get; set; }

            public Cell(int row, int col, GridType gridType)
            {
                Row = row;
                Column = col;
                GridType = gridType;
                IsSelected = false;
            }
        }

        /// <summary>
        /// Generate Images for the form application.
        /// </summary>
        public QGamePlayForm()
        {
            InitializeComponent();

            using (var ms = new MemoryStream(Resource.open_file_24))
            {
                loadImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.up_arrow_24))
            {
                upImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.down_arrow_24))
            {
                downImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.left_arrow_24))
            {
                leftImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.right_arrow_24))
            {
                rightImage = new Bitmap(ms);
            }

            buttonLoad.Image = loadImage;
            buttonUp.Image = upImage;
            buttonDown.Image = downImage;
            buttonLeft.Image = leftImage;
            buttonRight.Image = rightImage;


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
            using (var ms = new MemoryStream(Resource.blue_box_selected_1024))
            {
                blueBoxSelectedImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.green_box_selected_1024))
            {
                greenBoxSelectedImage = new Bitmap(ms);
            }
            using (var ms = new MemoryStream(Resource.red_box_selected_1024))
            {
                redBoxSelectedImage = new Bitmap(ms);
            }
        }

        /// <summary>
        /// Initializing the Grids out of picture boxes.
        /// </summary>
        /// <param name="numberOfRows">Rows for the new maze</param>
        /// <param name="numberOfColumns">Columns for the new maze</param>
        private void InitializeGrid(int numberOfRows, int numberOfColumns)
        {
            gridCells = new Cell[numberOfRows, numberOfColumns];

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

                    pictureBox.Click += OnCellClicked;

                    gridCells[i, j] = new Cell(i, j, GridType.Empty);
                    x += gridWidth + horizontalGap;
                }

                x = INIT_LEFT;
                y += gridHeight + verticalGap;
            }
        }

        /// <summary>
        /// Event for element that was clicked on.
        /// Checks if it's a box, then handles it properly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCellClicked(object sender, EventArgs e)
        {
            PictureBox pictureBoxClicked = sender as PictureBox;

            int selectedRow = Int32.Parse(pictureBoxClicked.Name.Split(',')[0]);
            int selectedCol = Int32.Parse(pictureBoxClicked.Name.Split(",")[1]);

            //if (selectedRow < 0 || selectedRow >= gridCells.GetLength(0) || selectedCol < 0 || selectedCol >= gridCells.GetLength(1))
            //{
            //    // Item out of bounds
            //    MessageBox.Show("Item out of bounds. Please click on the box within the maze!");
            //    return;
            //}

            Cell clickedCell = gridCells[selectedRow, selectedCol]; // Create an object of a sell that was clicked

            // Check if the clicked element is a box
            if (clickedCell.GridType == GridType.GreenBox || clickedCell.GridType == GridType.RedBox || clickedCell.GridType == GridType.BlueBox)
            {
                // Unselect previously selected box
                if (selectedBox != (-1, -1))
                {
                    int pastRow = selectedBox.X;
                    int pastColumn = selectedBox.Y;

                    if (pastRow >= 0 && pastRow < gridCells.GetLength(0) && pastColumn >= 0 && pastColumn < gridCells.GetLength(1))
                    {
                        gridCells[pastRow, pastColumn].IsSelected = false;  // Unselect
                        UpdateImages(pastRow, pastColumn, gridCells[pastRow, pastColumn].GridType); // Update image to initial
                    }
                }

                // Mark the new box as selected
                clickedCell.IsSelected = true;
                UpdateImages(selectedRow, selectedCol, clickedCell.GridType); // Update image to a selected

                selectedBox = (selectedRow, selectedCol);
            }
            else
            {
                // Deselect if clicked on anything else
                if (selectedBox != (-1, -1))
                {
                    int pastRow = selectedBox.X;
                    int pastColumn = selectedBox.Y;

                    if (pastRow >= 0 && pastRow < gridCells.GetLength(0) && pastColumn >= 0 && pastColumn < gridCells.GetLength(1))
                    {
                        gridCells[pastRow, pastColumn].IsSelected = false;  // Unselect
                        UpdateImages(pastRow, pastColumn, gridCells[pastRow, pastColumn].GridType); // Update image to initial
                    }
                }

                // Reset the selected box
                selectedBox = (-1, -1);
            }
        }

        // Button on-click events.
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadGridFromTxt();
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            int row = selectedBox.X;
            int col = selectedBox.Y;
            MoveBoxUp(row, col);
        }
        private void buttonDown_Click(object sender, EventArgs e)
        {
            int row = selectedBox.X;
            int col = selectedBox.Y;
            MoveBoxDown(row, col);
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            int row = selectedBox.X;
            int col = selectedBox.Y;
            MoveBoxLeft(row, col);
        }
        private void buttonRight_Click(object sender, EventArgs e)
        {
            int row = selectedBox.X;
            int col = selectedBox.Y;
            MoveBoxRight(row, col);
        }

        /// <summary>
        /// Method for moving a box UP using arrow.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void MoveBoxUp(int row, int col)
        {
            Cell currentCell = gridCells[row, col];
            int steps = 0;

            // Loop that will make sure box is moved until an obstacle like wall or other box is met
            while (row - 1 >= 0)
            {
                Cell upCell = gridCells[row - 1, col];

                // Checking if the cell above is not empty meaning box can't move any further
                if (upCell.GridType != GridType.Empty)
                {
                    break;
                }

                // Replacing cell above with our box
                upCell.GridType = currentCell.GridType;
                currentCell.GridType = GridType.Empty;

                // Updating the image for the previous spot of the box
                UpdateImages(row, col, currentCell.GridType);

                row--;
                currentCell = upCell;
                steps++;
            }
            movesCount += steps;
            selectedBox = (row, col);

            textBoxNumberOfMoves.Text = movesCount.ToString();
            textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();

            if (steps > 0)
            {
                RemoveBox(row, col, "up");   // Remove the box from the previous position
                UpdateImages(row, col, currentCell.GridType); // Update the image for the new cell of the box

                // Checking if there're any boxes left in the grid
                if (WinCheck())
                {

                    MessageBox.Show("You won!", "All the Boxes are in their Doors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
            }
        }

        /// <summary>
        /// Method for moving a box DOWN using arrow.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void MoveBoxDown(int row, int col)
        {
            Cell currentCell = gridCells[row, col];
            int steps = 0;

            // Loop that will make sure box is moved until an obstacle like wall or other box is met
            while (row + 1 < gridCells.GetLength(0))
            {
                Cell downCell = gridCells[row + 1, col];

                // Checking if the cell below is not empty meaning box can't move any further
                if (downCell.GridType != GridType.Empty)
                {
                    break;
                }



                // Replacing cell below with our box
                downCell.GridType = currentCell.GridType;
                currentCell.GridType = GridType.Empty;

                // Updating the image for the previous spot of the box
                UpdateImages(row, col, currentCell.GridType);

                row++;
                currentCell = downCell;
                steps++;
            }
            movesCount += steps;
            selectedBox = (row, col);

            textBoxNumberOfMoves.Text = movesCount.ToString();
            textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();

            if (steps > 0)
            {
                RemoveBox(row, col, "down");    // Remove the box from the previous position
                UpdateImages(row, col, currentCell.GridType);  // Update the image for the new cell of the box

                // Checking if there're any boxes left in the grid
                if (WinCheck())
                {
                    MessageBox.Show("You won!", "All the Boxes are in their Doors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
            }
        }
        /// <summary>
        /// Method for moving a box LEFT using arrow.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>

        public void MoveBoxLeft(int row, int col)
        {
            Cell currentCell = gridCells[row, col];
            int steps = 0;

            // Loop that will make sure box is moved until an obstacle like wall or other box is met
            while (col - 1 >= 0)
            {
                Cell leftCell = gridCells[row, col - 1];

                // Checking if the cell to the left is not empty meaning box can't move any further
                if (leftCell.GridType != GridType.Empty)
                {
                    break;
                }

                // Replacing cell to the left with our box
                leftCell.GridType = currentCell.GridType;
                currentCell.GridType = GridType.Empty;

                // Updating the image for the previous spot of the box
                UpdateImages(row, col, currentCell.GridType);

                col--;
                currentCell = leftCell;
                steps++;
            }
            movesCount += steps;
            selectedBox = (row, col);

            textBoxNumberOfMoves.Text = movesCount.ToString();
            textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();

            if (steps > 0)
            {
                RemoveBox(row, col, "left");    // Remove the box from the previous position
                UpdateImages(row, col, currentCell.GridType);    // Update the image for the new cell of the box

                // Checking if there're any boxes left in the grid
                if (WinCheck())
                {
                    MessageBox.Show("You won!", "All the Boxes are in their Doors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
            }
        }

        /// <summary>
        /// Method for moving a box RIGHT using arrow.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void MoveBoxRight(int row, int col)
        {
            Cell currentCell = gridCells[row, col];
            int steps = 0;

            // Loop that will make sure box is moved until an obstacle like wall or other box is met
            while (col + 1 < gridCells.GetLength(1))
            {
                Cell rightCell = gridCells[row, col + 1];

                // Checking if the cell to the left is not empty meaning box can't move any further
                if (rightCell.GridType != GridType.Empty)
                {
                    break;
                }

                // Replacing cell to the right with our box
                rightCell.GridType = currentCell.GridType;
                currentCell.GridType = GridType.Empty;

                // Updating the image for the previous spot of the box
                UpdateImages(row, col, currentCell.GridType);

                col++;
                currentCell = rightCell;
                steps++;
            }
            movesCount += steps;
            selectedBox = (row, col);

            textBoxNumberOfMoves.Text = movesCount.ToString();
            textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();

            if (steps > 0)
            {
                RemoveBox(row, col, "right");   // Remove the box from the previous position
                UpdateImages(row, col, currentCell.GridType);  // Update the image for the new cell of the box

                // Checking if there're any boxes left in the grid
                if (WinCheck())
                {
                    MessageBox.Show("You won!", "All the Boxes are in their Doors", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                }
            }
        }

        /// <summary>
        /// Removing the box if it's next to the door of its color.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="direction">What was the last pressed controller</param>
        private void RemoveBox(int row, int col, string direction)
        {
            GridType box = gridCells[row, col].GridType;

            if (box == GridType.RedBox || box == GridType.GreenBox || box == GridType.BlueBox)
            {
                bool deleteBox = false;

                // Checking if last controller pressed was UP
                if (direction == "up")
                {
                    if (row - 1 >= 0)
                    {
                        Cell door = gridCells[row - 1, col];
                        // Checking for the door of the same color next to the box 
                        if ((box == GridType.GreenBox && door.GridType == GridType.GreenDoor) || (box == GridType.BlueBox && door.GridType == GridType.BlueDoor) || (box == GridType.RedBox && door.GridType == GridType.RedDoor))
                        {
                            deleteBox = true;
                        }
                    }
                }
                // Checking if last controller pressed was DOWN
                else if (direction == "down")
                {
                    if (row + 1 < gridCells.GetLength(0))
                    {
                        Cell door = gridCells[row + 1, col];
                        // Checking for the door of the same color next to the box 
                        if ((box == GridType.GreenBox && door.GridType == GridType.GreenDoor) || (box == GridType.BlueBox && door.GridType == GridType.BlueDoor) || (box == GridType.RedBox && door.GridType == GridType.RedDoor))
                        {
                            deleteBox = true;
                        }
                    }
                }
                // Checking if last controller pressed was LEFT
                else if (direction == "left")
                {
                    if (col - 1 >= 0)
                    {
                        Cell door = gridCells[row, col - 1];
                        // Checking for the door of the same color next to the box 
                        if ((box == GridType.GreenBox && door.GridType == GridType.GreenDoor) || (box == GridType.BlueBox && door.GridType == GridType.BlueDoor) || (box == GridType.RedBox && door.GridType == GridType.RedDoor))
                        {
                            deleteBox = true;
                        }
                    }
                }
                // Checking if last controller pressed was RIGHT
                else if (direction == "right")
                {
                    if (col + 1 < gridCells.GetLength(1))
                    {
                        Cell door = gridCells[row, col + 1];
                        // Checking for the door of the same color next to the box 
                        if ((box == GridType.GreenBox && door.GridType == GridType.GreenDoor) || (box == GridType.BlueBox && door.GridType == GridType.BlueDoor) || (box == GridType.RedBox && door.GridType == GridType.RedDoor))
                        {
                            deleteBox = true;
                        }
                    }
                }
                if (deleteBox)
                {
                    boxesRemainingCount--;
                    gridCells[row, col].GridType = GridType.Empty;
                    UpdateImages(row, col, GridType.Empty);
                }
            }
        }

        /// <summary>
        /// Checking for a Win.
        /// If there are no boxes left in the grid.
        /// </summary>
        /// <returns></returns>
        private bool WinCheck()
        {
            foreach (var cell in gridCells)
            {
                if (cell.GridType == GridType.RedBox)
                {
                    return false;
                }
                if (cell.GridType == GridType.GreenBox)
                {
                    return false;
                }
                if (cell.GridType == GridType.BlueBox)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Resetting method.
        /// Deletes all the picture boxes and sets text boxes to '0'.
        /// </summary>
        private void ResetGame()
        {
            RemovePictureBoxes();

            movesCount = 0;
            boxesRemainingCount = 0;
            textBoxNumberOfMoves.Text = movesCount.ToString();
            textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();
        }

        //private void UpdateImages(int row, int col, GridType gridType)
        //{
        //    PictureBox pictureBoxToUpdate = pictureBoxDictionary[(row, col)];

        //    if (gridCells[row, col].IsSelected)
        //    {
        //        if (gridType == GridType.BlueBox)
        //        {
        //            pictureBoxToUpdate.Image = blueBoxSelectedImage;
        //        }
        //        else if (gridType == GridType.GreenBox)
        //        {
        //            pictureBoxToUpdate.Image = greenBoxSelectedImage;
        //        }
        //        else if (gridType == GridType.RedBox)
        //        {
        //            pictureBoxToUpdate.Image = redBoxSelectedImage;
        //        }
        //    }
        //    else
        //    {
        //        if (gridType == GridType.Empty)
        //        {
        //            pictureBoxToUpdate.Image = noneImage2;
        //        }
        //        else if (gridType == GridType.Wall)
        //        {
        //            pictureBoxToUpdate.Image = wallImage;
        //        }
        //        else if (gridType == GridType.RedDoor)
        //        {
        //            pictureBoxToUpdate.Image = redDoorImage;
        //        }
        //        else if (gridType == GridType.BlueDoor)
        //        {
        //            pictureBoxToUpdate.Image = blueDoorImage;
        //        }
        //        else if (gridType == GridType.GreenDoor)
        //        {
        //            pictureBoxToUpdate.Image = greenDoorImage;
        //        }
        //        else if (gridType == GridType.RedBox)
        //        {
        //            pictureBoxToUpdate.Image = redBoxImage;
        //        }
        //        else if (gridType == GridType.BlueBox)
        //        {
        //            pictureBoxToUpdate.Image = blueBoxImage;
        //        }
        //        else if (gridType == GridType.GreenBox)
        //        {
        //            pictureBoxToUpdate.Image = greenBoxImage;
        //        }
        //    }
        //}



        /// <summary>
        /// Updating images for the specified element.
        /// </summary>
        /// <param name="row">Row of the element</param>
        /// <param name="col">Column of the element</param>
        /// <param name="gridType"></param>
        private void UpdateImages(int row, int col, GridType gridType)
        {
            PictureBox pictureBoxToUpdate = pictureBoxDictionary[(row, col)];

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
        }

        /// <summary>
        /// Deletes all the picture boxes.
        /// </summary>
        private void RemovePictureBoxes()
        {
            List<Control> pictureBoxes = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is PictureBox)
                {
                    pictureBoxes.Add(control);
                }
            }

            foreach (Control pictureBox in pictureBoxes)
            {
                Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }


        /// <summary>
        /// Method to load grid from the text file.
        /// This method was used in Design part.
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
                        gridCells = new Cell[numberOfRows, numberOfColumns];

                        RemovePictureBoxes();
                        InitializeGrid(numberOfRows, numberOfColumns); // Initializing empty grid

                        int boxCount = 0;

                        for (int i = 0; i < numberOfRows; i++)
                        {
                            string line = reader.ReadLine();
                            string[] elements = line.Split("|"); // Getting a line from the file and splitting it by the separator

                            for (int j = 0; j < numberOfColumns; j++)
                            {
                                GridType gridType = GridElementSerialize(elements[j]);
                                gridCells[i, j] = new Cell(i, j, gridType);
                                UpdateImages(i, j, gridType);

                                if (gridType == GridType.GreenBox || gridType == GridType.BlueBox || gridType == GridType.RedBox)
                                {
                                    boxCount++;
                                }
                            }
                        }

                        movesCount = 0;
                        boxesRemainingCount = boxCount;

                        textBoxNumberOfMoves.Text = movesCount.ToString();
                        textBoxNumberOfBoxes.Text = boxesRemainingCount.ToString();

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color darkBlue = Color.DarkBlue;
            Color lightBlue = Color.LightBlue;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                darkBlue,
                lightBlue,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Color darkRed = Color.LightPink;
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
    }
}