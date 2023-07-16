namespace APIIntegration.Model.Common
{
    /// <summary>
    /// Aggregate root
    /// </summary>
    public abstract class AggregateRoot
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether the entity is processed.
        /// </summary>
        public bool IsProcessed { get; set; }

        /// <summary>
        /// Gets or sets a boolean value indicating whether the entity is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
