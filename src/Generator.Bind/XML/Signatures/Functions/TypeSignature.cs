using System;
using JetBrains.Annotations;

namespace Bind.XML.Signatures.Functions
{
    /// <summary>
    /// Represents a type signature in an API.
    /// </summary>
    public class TypeSignature : IEquatable<TypeSignature>
    {
        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        [NotNull]
        public string Name { get; }

        /// <summary>
        /// Gets the level of indirection (i.e, the number of pointer levels) of the type.
        /// </summary>
        public int IndirectionLevel { get; }

        /// <summary>
        /// Gets the number of array dimensions of the type.
        /// </summary>
        public int ArrayDimensions { get; }

        /// <summary>
        /// Gets a value indicating whether the type is a pointer.
        /// </summary>
        public bool IsPointer => IndirectionLevel > 0;

        /// <summary>
        /// Gets a value indicating whether the type is an array.
        /// </summary>
        public bool IsArray => ArrayDimensions > 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeSignature"/> class.
        /// </summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="indirectionLevel">The level of indirection the type has.</param>
        /// <param name="arrayDimensions">The number of array dimensions the type has.</param>
        public TypeSignature([NotNull] string name, int indirectionLevel, int arrayDimensions)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ArrayDimensions = arrayDimensions;
            IndirectionLevel = indirectionLevel;
        }

        /// <inheritdoc/>
        public bool Equals(TypeSignature other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(Name, other.Name)
                   && IndirectionLevel == other.IndirectionLevel
                   && ArrayDimensions == other.ArrayDimensions;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((TypeSignature)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ IndirectionLevel;
                hashCode = (hashCode * 397) ^ ArrayDimensions;
                return hashCode;
            }
        }

        /// <summary>
        /// Determines if two <see cref="TypeSignature"/> instances are equal.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>true if the instances are equal; otherwise, false.</returns>
        public static bool operator ==([CanBeNull] TypeSignature left, [CanBeNull] TypeSignature right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Determines if two <see cref="TypeSignature"/> instances are not equal.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>true if the instances are not equal; otherwise, false.</returns>
        public static bool operator !=([CanBeNull] TypeSignature left, [CanBeNull] TypeSignature right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name;
        }
    }
}
