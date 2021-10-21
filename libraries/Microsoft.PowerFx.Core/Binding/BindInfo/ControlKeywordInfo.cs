//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using Microsoft.PowerFx.Core.App.Controls;
using Microsoft.PowerFx.Core.Syntax.Nodes;
using Microsoft.PowerFx.Core.Utils;

namespace Microsoft.PowerFx.Core.Binding.BindInfo
{
    internal abstract class ControlKeywordInfo : NameInfo
    {
        // Qualifying path. May be DPath.Root (unqualified).
        public readonly DPath Path;

        // Data associated with a control keyword node. May be null.
        public readonly IExternalControl Data;

        public ControlKeywordInfo(NameNode node, DPath path, IExternalControl data)
            : base(BindKind.Control, node.VerifyValue())
        {
            Contracts.AssertValid(path);
            Contracts.AssertValueOrNull(data);

            Path = path;
            Data = data;
        }
    }
}