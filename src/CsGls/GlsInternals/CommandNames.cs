using System.Collections.Generic;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.GlsInternals
{
    /// <summary>
    /// Static names of known commands.
    /// </summary>
    public class CommandNames {
        /// <summary>
        /// Name key for the ArrayIndex command.
        /// </summary>
        public static readonly string ArrayIndex = "array index";

        /// <summary>
        /// Name key for the ArrayInitialize command.
        /// </summary>
        public static readonly string ArrayInitialize = "array initialize";

        /// <summary>
        /// Name key for the ArrayLength command.
        /// </summary>
        public static readonly string ArrayLength = "array length";

        /// <summary>
        /// Name key for the ArrayType command.
        /// </summary>
        public static readonly string ArrayType = "array type";

        /// <summary>
        /// Name key for the Break command.
        /// </summary>
        public static readonly string Break = "break";

        /// <summary>
        /// Name key for the CatchEnd command.
        /// </summary>
        public static readonly string CatchEnd = "catch end";

        /// <summary>
        /// Name key for the CatchStart command.
        /// </summary>
        public static readonly string CatchStart = "catch start";

        /// <summary>
        /// Name key for the ClassEnd command.
        /// </summary>
        public static readonly string ClassEnd = "class end";

        /// <summary>
        /// Name key for the ClassStart command.
        /// </summary>
        public static readonly string ClassStart = "class start";

        /// <summary>
        /// Name key for the CommentBlock command.
        /// </summary>
        public static readonly string CommentBlock = "comment block";

        /// <summary>
        /// Name key for the CommentBlockEnd command.
        /// </summary>
        public static readonly string CommentBlockEnd = "comment block end";

        /// <summary>
        /// Name key for the CommentBlockStart command.
        /// </summary>
        public static readonly string CommentBlockStart = "comment block start";

        /// <summary>
        /// Name key for the CommentBlockStart command.
        /// </summary>
        public static readonly string CommentDocEnd = "comment doc end";

        /// <summary>
        /// Name key for the  command.
        /// </summary>
        public static readonly string CommentDocStart = "comment doc start";

        /// <summary>
        /// Name key for the CommentDocTag command.
        /// </summary>
        public static readonly string CommentDocTag = "comment doc tag";

        /// <summary>
        /// Name key for the CommentLine command.
        /// </summary>
        public static readonly string CommentLine = "comment line";

        /// <summary>
        /// Name key for the Concatenate command.
        /// </summary>
        public static readonly string Concatenate = "concatenate";

        /// <summary>
        /// Name key for the ConstructorEnd command.
        /// </summary>
        public static readonly string ConstructorEnd = "constructor end";

        /// <summary>
        /// Name key for the ConstructorStart command.
        /// </summary>
        public static readonly string ConstructorStart = "constructor start";

        /// <summary>
        /// Name key for the Continue command.
        /// </summary>
        public static readonly string Continue = "continue";

        /// <summary>
        /// Name key for the DictionaryContainsKey command.
        /// </summary>
        public static readonly string DictionaryContainsKey = "dictionary contains key";

        /// <summary>
        /// Name key for the DictionaryIndex command.
        /// </summary>
        public static readonly string DictionaryIndex = "dictionary index";

        /// <summary>
        /// Name key for the DictionaryKeys command.
        /// </summary>
        public static readonly string DictionaryKeys = "dictionary keys";

        /// <summary>
        /// Name key for the DictionaryNew command.
        /// </summary>
        public static readonly string DictionaryNew = "dictionary initialize";

        /// <summary>
        /// Name key for the DictionaryNewEnd command.
        /// </summary>
        public static readonly string DictionaryNewEnd = "dictionary initialize end";

        /// <summary>
        /// Name key for the DictionaryNewStart command.
        /// </summary>
        public static readonly string DictionaryNewStart = "dictionary initialize start";

        /// <summary>
        /// Name key for the DictionaryPair command.
        /// </summary>
        public static readonly string DictionaryPair = "dictionary pair";

        /// <summary>
        /// Name key for the DictionaryType command.
        /// </summary>
        public static readonly string DictionaryType = "dictionary type";

        /// <summary>
        /// Name key for the ElseIfStart command.
        /// </summary>
        public static readonly string ElseIfStart = "else if start";

        /// <summary>
        /// Name key for the ElseStart command.
        /// </summary>
        public static readonly string ElseStart = "else start";

        /// <summary>
        /// Name key for the Enum command.
        /// </summary>
        public static readonly string Enum = "enum";

        /// <summary>
        /// Name key for the EnumEnd command.
        /// </summary>
        public static readonly string EnumEnd = "enum end";

        /// <summary>
        /// Name key for the EnumMember command.
        /// </summary>
        public static readonly string EnumMember = "enum member";

        /// <summary>
        /// Name key the EnumStart command.
        /// </summary>
        public static readonly string EnumStart = "enum start";

        /// <summary>
        /// Name key for the FileEnd command.
        /// </summary>
        public static readonly string FileEnd = "file end";

        /// <summary>
        /// Name key for the FileStart command.
        /// </summary>
        public static readonly string FileStart = "file start";

        /// <summary>
        /// Name key for the FinallyEnd command.
        /// </summary>
        public static readonly string FinallyEnd = "finally end";

        /// <summary>
        /// Name key for the FinallyStart command.
        /// </summary>
        public static readonly string FinallyStart = "finally start";

        /// <summary>
        /// Name key for the ForEachEnd command.
        /// </summary>
        public static readonly string ForEachEnd = "for each end";

        /// <summary>
        /// Name key for the ForEachKeyStart command.
        /// </summary>
        public static readonly string ForEachKeyStart = "for each key start";

        /// <summary>
        /// Name key for the ForEachPairStart command.
        /// </summary>
        public static readonly string ForEachPairStart = "for each pair start";

        /// <summary>
        /// Name key for the ForEachStart command.
        /// </summary>
        public static readonly string ForEachStart = "for each start";

        /// <summary>
        /// Name key for the ForNumbersEnd command.
        /// </summary>
        public static readonly string ForNumbersEnd = "for numbers end";

        /// <summary>
        /// Name key for the ForNumbersStart command.
        /// </summary>
        public static readonly string ForNumbersStart = "for numbers start";

        /// <summary>
        /// Name key for the Function command.
        /// </summary>
        public static readonly string Function = "function";

        /// <summary>
        /// Name key for the FunctionEnd command.
        /// </summary>
        public static readonly string FunctionEnd = "function end";

        /// <summary>
        /// Name key for the FunctionStart command.
        /// </summary>
        public static readonly string FunctionStart = "function start";

        /// <summary>
        /// Name key for the GenericType command.
        /// </summary>
        public static readonly string GenericType = "generic type";

        /// <summary>
        /// Name key for the IfEnd command.
        /// </summary>
        public static readonly string IfEnd = "if end";

        /// <summary>
        /// Name key for the IfStart command.
        /// </summary>
        public static readonly string IfStart = "if start";

        /// <summary>
        /// Name key for the IfStringToFloatEnd command.
        /// </summary>
        public static readonly string IfStringToFloatEnd = "if string to float end";

        /// <summary>
        /// Name key for the IfStringToFloatStart command.
        /// </summary>
        public static readonly string IfStringToFloatStart = "if string to float start";

        /// <summary>
        /// Name key for the ImportLocal command.
        /// </summary>
        public static readonly string ImportLocal = "import local";

        /// <summary>
        /// Name key for the ImportPackage command.
        /// </summary>
        public static readonly string ImportPackage = "import package";

        /// <summary>
        /// Name key for the InstanceOf command.
        /// </summary>
        public static readonly string InstanceOf = "instance of";

        /// <summary>
        /// Name key for the InterfaceEnd command.
        /// </summary>
        public static readonly string InterfaceEnd = "interface end";

        /// <summary>
        /// Name key for the InterfaceMethod command.
        /// </summary>
        public static readonly string InterfaceMethod = "interface method";

        /// <summary>
        /// Name key for the InterfaceStart command.
        /// </summary>
        public static readonly string InterfaceStart = "interface start";

        /// <summary>
        /// Name key for the IsNotNull command.
        /// </summary>
        public static readonly string IsNotNull = "is not null";

        /// <summary>
        /// Name key for the IsNull command.
        /// </summary>
        public static readonly string IsNull = "is null";

        /// <summary>
        /// Name key for the LambdaBody command.
        /// </summary>
        public static readonly string LambdaBody = "lambda";

        /// <summary>
        /// Name key for the LambdaBody command.
        /// </summary>
        public static readonly string ListAddList = "list add list";

        /// <summary>
        /// Name key for the ListIndex command.
        /// </summary>
        public static readonly string ListIndex = "list index";

        /// <summary>
        /// Name key for the ListInitialize command.
        /// </summary>
        public static readonly string ListInitialize = "list initialize";

        /// <summary>
        /// Name key for the ListLength command.
        /// </summary>
        public static readonly string ListLength = "list length";

        /// <summary>
        /// Name key for the ListPop command.
        /// </summary>
        public static readonly string ListPop = "list pop";

        /// <summary>
        /// Name key the ListPopFront command.
        /// </summary>
        public static readonly string ListPopFront = "list pop front";

        /// <summary>
        /// Name key for the ListPush command.
        /// </summary>
        public static readonly string ListPush = "list push";

        /// <summary>
        /// Name key for the ListSort command.
        /// </summary>
        public static readonly string ListSort = "list sort";

        /// <summary>
        /// Name key for the ListType command.
        /// </summary>
        public static readonly string ListType = "list type";

        /// <summary>
        /// Name key for the Literal command.
        /// </summary>
        public static readonly string Literal = "literal";

        /// <summary>
        /// Name key for the MainContextEnd command.
        /// </summary>
        public static readonly string MainContextEnd = "main context end";

        /// <summary>
        /// Name key for the MainContextStart command.
        /// </summary>
        public static readonly string MainContextStart = "main context start";

        /// <summary>
        /// Name key for the MainEnd command.
        /// </summary>
        public static readonly string MainEnd = "main end";

        /// <summary>
        /// Name key for the MainStart command.
        /// </summary>
        public static readonly string MainStart = "main start";

        /// <summary>
        /// Name key for the MathAbsolute command.
        /// </summary>
        public static readonly string MathAbsolute = "math absolute";

        /// <summary>
        /// Name key for the MathCeiling command.
        /// </summary>
        public static readonly string MathCeiling = "math ceiling";

        /// <summary>
        /// Name key for the MathFloor command.
        /// </summary>
        public static readonly string MathFloor = "math floor";

        /// <summary>
        /// Name key for the MathMax command.
        /// </summary>
        public static readonly string MathMax = "math max";

        /// <summary>
        /// Name key for the MathMin command.
        /// </summary>
        public static readonly string MathMin = "math min";

        /// <summary>
        /// Name key for the MathPower command.
        /// </summary>
        public static readonly string MathPower = "math power";

        /// <summary>
        /// Name key for the MemberFunction command.
        /// </summary>
        public static readonly string MemberFunction = "member function";

        /// <summary>
        /// Name key for the MemberFunctionDeclareAbstract command.
        /// </summary>
        public static readonly string MemberFunctionDeclareAbstract = "member function declare abstract";

        /// <summary>
        /// Name key for the MemberFunctionDeclareEnd command.
        /// </summary>
        public static readonly string MemberFunctionDeclareEnd = "member function declare end";

        /// <summary>
        /// Name key for the MemberFunctionDeclareStart command.
        /// </summary>
        public static readonly string MemberFunctionDeclareStart = "member function declare start";

        /// <summary>
        /// Name key for the MemberVariable command.
        /// </summary>
        public static readonly string MemberVariable = "member variable";

        /// <summary>
        /// Name key for the MemberVariableDeclare command.
        /// </summary>
        public static readonly string MemberVariableDeclare = "member variable declare";

        /// <summary>
        /// Name key for the New command.
        /// </summary>
        public static readonly string New = "new";

        /// <summary>
        /// Name key for the Not command.
        /// </summary>
        public static readonly string Not = "not";

        /// <summary>
        /// Name key for the Operation command.
        /// </summary>
        public static readonly string Operation = "operation";

        /// <summary>
        /// Name key for the Operator command.
        /// </summary>
        public static readonly string Operator = "operator";

        /// <summary>
        /// Name key for the Parenthesis command.
        /// </summary>
        public static readonly string Parenthesis = "parenthesis";

        /// <summary>
        /// Name key for the Print command.
        /// </summary>
        public static readonly string Print = "print";

        /// <summary>
        /// Name key for the RestParameters command.
        /// </summary>
        public static readonly string RestParameters = "rest parameters";

        /// <summary>
        /// Name key for the Return command.
        /// </summary>
        public static readonly string Return = "return";

        /// <summary>
        /// Name key for the SetAdd command.
        /// </summary>
        public static readonly string SetAdd = "set add";

        /// <summary>
        /// Name key for the SetContains command.
        /// </summary>
        public static readonly string SetContains = "set contains";

        /// <summary>
        /// Name key for the SetToArray command.
        /// </summary>
        public static readonly string SetToArray = "set to array";

        /// <summary>
        /// Name key for the SetToList command.
        /// </summary>
        public static readonly string SetToList = "set to list";

        /// <summary>
        /// Name key for the SetNew command.
        /// </summary>
        public static readonly string SetNew = "set new";

        /// <summary>
        /// Name key for the SetType command.
        /// </summary>
        public static readonly string SetType = "set type";

        /// <summary>
        /// Name key for the StaticFunction command.
        /// </summary>
        public static readonly string StaticFunction = "static function";

        /// <summary>
        /// Name key for the StaticFunctionDeclareEnd command.
        /// </summary>
        public static readonly string StaticFunctionDeclareEnd = "static function declare end";

        /// <summary>
        /// Name key for the StaticFunctionDeclareStart command.
        /// </summary>
        public static readonly string StaticFunctionDeclareStart = "static function declare start";

        /// <summary>
        /// Name key for the StaticVariable command.
        /// </summary>
        public static readonly string StaticVariable = "static variable";

        /// <summary>
        /// Name key for the StaticVariableDeclare command.
        /// </summary>
        public static readonly string StaticVariableDeclare = "static variable declare";

        /// <summary>
        /// Name key the StringFormat command.
        /// </summary>
        public static readonly string StringFormat = "string format";

        /// <summary>
        /// Name key for the StringIndex command.
        /// </summary>
        public static readonly string StringIndex = "string index";

        /// <summary>
        /// Name key for the StringLength command.
        /// </summary>
        public static readonly string StringLength = "string length";

        /// <summary>
        /// Name key for the StringSubstringIndex command.
        /// </summary>
        public static readonly string StringSubstringIndex = "string substring index";

        /// <summary>
        /// Name key for the StringSubstringLength command.
        /// </summary>
        public static readonly string StringSubstringLength = "string substring length";

        /// <summary>
        /// Name key for the StringCaseLower command.
        /// </summary>
        public static readonly string StringCaseLower = "string case lower";

        /// <summary>
        /// Name key for the StringCaseUpper command.
        /// </summary>
        public static readonly string StringCaseUpper = "string case upper";

        /// <summary>
        /// Name key for the SuperConstructor command.
        /// </summary>
        public static readonly string SuperConstructor = "super constructor";

        /// <summary>
        /// Name key for the This command.
        /// </summary>
        public static readonly string This = "this";

        /// <summary>
        /// Name key for the ThrowException command.
        /// </summary>
        public static readonly string ThrowException = "throw exception";

        /// <summary>
        /// Name key for the TryEnd command.
        /// </summary>
        public static readonly string TryEnd = "try end";

        /// <summary>
        /// Name key for the TryStart command.
        /// </summary>
        public static readonly string TryStart = "try start";

        /// <summary>
        /// Name key for the Type command.
        /// </summary>
        public static readonly string Type = "type";

        /// <summary>
        /// Name key for the Value command.
        /// </summary>
        public static readonly string Value = "value";

        /// <summary>
        /// Name key for the Variable command.
        /// </summary>
        public static readonly string Variable = "variable";

        /// <summary>
        /// Name key for the VariableInline command.
        /// </summary>
        public static readonly string VariableInline = "variable inline";

        /// <summary>
        /// Name key for the VariableStart command.
        /// </summary>
        public static readonly string VariableStart = "variable start";

        /// <summary>
        /// Name key the WhileEnd command.
        /// </summary>
        public static readonly string WhileEnd = "while end";

        /// <summary>
        /// Name key for the WhileStart command.
        /// </summary>
        public static readonly string WhileStart = "while start";
    }
}
