﻿//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using Microsoft.PowerFx.Core.Syntax;
using Microsoft.PowerFx.Core.Syntax.Nodes;
using Microsoft.PowerFx.Core.Types;
using Microsoft.PowerFx.Core.Utils;

namespace Microsoft.PowerFx.Core.Texl.Intellisense{
    internal partial class Intellisense
    {
        internal sealed class StrNumLitNodeSuggestionHandler : ISuggestionHandler
        {
            public StrNumLitNodeSuggestionHandler()
            { }

            /// <summary>
            /// Adds suggestions as appropriate to the internal Suggestions and SubstringSuggestions lists of intellisenseData.
            /// Returns true if intellisenseData is handled and no more suggestions are to be found and false otherwise.
            /// </summary>
            public bool Run(IntellisenseData.IntellisenseData intellisenseData)
            {
                Contracts.AssertValue(intellisenseData);
                Contracts.AssertValue(intellisenseData.CurNode);

                if (intellisenseData.CurNode.Kind != NodeKind.StrLit && intellisenseData.CurNode.Kind != NodeKind.NumLit)
                    return false;

                TexlNode curNode = intellisenseData.CurNode;
                int cursorPos = intellisenseData.CursorPos;
                var tokenSpan = curNode.Token.Span;
                // Should not suggest anything if the cursor is before the string/number.
                if (cursorPos > tokenSpan.Lim && IntellisenseHelper.CanSuggestAfterValue(cursorPos, intellisenseData.Script))
                {
                    // Cursor is after the current node's token.
                    // Suggest binary kewords.
                    DType operandType = curNode.Kind == NodeKind.StrLit ? DType.String : DType.Number;
                    IntellisenseHelper.AddSuggestionsForAfterValue(intellisenseData, operandType);
                }
                else if (cursorPos > tokenSpan.Min)
                {
                    // Cursor is in the middle of the token, Suggest Globals matching the input string or number.
                    int replacementLength = tokenSpan.Lim - tokenSpan.Min;
                    intellisenseData.SetMatchArea(tokenSpan.Min, cursorPos, replacementLength);
                    IntellisenseHelper.AddSuggestionsForGlobals(intellisenseData);
                }
                return true;
            }
        }
    }
}