namespace NeuroNet.Core.Common
{
    public enum CellType
    {
        /// <summary>
        /// InputCell in input layer (i.e. sensor or S-element)
        /// </summary>
        Input,
        /// <summary>
        /// InputCell in output layer (i.e. A-element)
        /// </summary>
        Output,
        /// <summary>
        /// InputCell in hidden layer (i.e. receptor or R-element)
        /// </summary>
        Hidden,
        /// <summary>
        /// InputCell position is unknown
        /// </summary>
        Unknown
    }
}