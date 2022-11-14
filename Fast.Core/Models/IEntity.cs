using System;



namespace Fast.Core
{
    /// <summary>
    /// Defines the basic identification properties in a relational database.
    /// </summary>
    public interface IEntity<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public T Id { get; set; }
        /// <summary>
        /// Implementation for local databases.
        /// </summary>
        public Guid Guid { get; set; }


    }


    public interface IEntity : IEntity<int>
    {

    }
}
