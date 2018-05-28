﻿using System.IO;
using Bind.GL2;

namespace Bind.ES
{
    /// <summary>
    /// Generates API bindings for OpenGL ES 3.0.
    /// </summary>
    internal class ES3Generator : Generator
    {
        /// <inheritdoc/>
        public override string OutputSubfolder => "ES30";

        /// <inheritdoc/>
        public override string Namespace => "OpenTK.Graphics.ES30";

        /// <inheritdoc/>
        public override string SpecificationDocumentationPath => "ES30";

        /// <inheritdoc/>
        protected override string ProfileName => "gles2";

        /// <inheritdoc/>
        protected override string Version => "2.0|3.0";

        /// <summary>
        /// Initializes a new instance of the <see cref="ES3Generator"/> class.
        /// </summary>
        public ES3Generator()
        {
            OverrideFiles = new[]
            {
                Path.Combine(Program.Arguments.InputPath, "GL2", "overrides.xml")
            };
        }
    }
}
