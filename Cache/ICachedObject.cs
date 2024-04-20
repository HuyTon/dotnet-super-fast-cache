using System;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// Generic interface for the cache object
    /// to ensure that any cached object can
    /// be added to the cache as long as it
    /// implements Id and Name.
    /// </summary>
    public interface ICachedObject : IComparable
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; } // Add Description property
    }
}
