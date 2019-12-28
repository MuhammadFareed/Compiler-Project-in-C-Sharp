using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Final_Project
{
    class FunctionsForTokenization
    {
        public string Keywords(string SplittedString)               // Function for recognizing Keywords...
        {
            Dictionary<string, string> Dictkeyword = new Dictionary<string, string>()
            {
                {"abstract","Keyword" },
                {"byte","Keyword" },
                {"class","Keyword" },
                {"delegate","Keyword" },
                {"event","Keyword" },
                {"fixed","Keyword" },
                {"if","Keyword" },
                {"internal","Keyword" },
                {"new","Keyword" },
                {"override","Keyword" },
                {"readonly","Keyword" },
                {"struct","Keyword" },
                {"try","Keyword" },
                {"unsafe","Keyword" },
                {"switch","Keyword" },
                {"do","Keyword" },
                {"while","Keyword" },
                {"catch","Keyword" },
                {"continue","Keyword" },
                {"this","Keyword" },
                {"using","Keyword" },
                {"else","Keyword" },
                {"return","Keyword" },
                {"for","Keyword" },
                {"private","Keyword" },
                {"static","Keyword" },
                {"foreach","Keyword" },
                {"protected","Keyword" },
                {"throw","Keyword" },
                {"break","Keyword" },
                {"namespace","Keyword" },
                {"interface","Keyword" },
                {"public","Keyword" },
                {"enum","Keyword" },
                {"string","Keyword" },
                {"int","Keyword" },
                {"float","Keyword" },
                {"bool","Keyword" },
                {"double","Keyword"},
                {"char","Keyword" },
                {"sbyte","Keyword" },
                {"short","Keyword" },
                {"long","Keyword" },
                {"ushort","Keyword" },
                {"uint","Keyword" },
                {"ulong","Keyword" },
                {"decimal","Keyword" },
                {"null","Keyword" }
            };

            foreach (KeyValuePair<string, string> s in Dictkeyword)
            {
                if (s.Key == SplittedString)
                {
                    return Dictkeyword[SplittedString];
                }
            }
            return null;
        }

        public string Symbols(string SplittedString)             // Function for recognizing Symbols...
        {
            Dictionary<string, string> DictSymbol = new Dictionary<string, string>()
            {
                {"(","OpeningRoundBracket" },
                {")","ClosingRoundBracket" },
                {"{","OpeningCurlyBracket" },
                {"}","ClosingCurlyBracket" },
                {"[","OpeningSquareBracket" },
                {"]","ClosingSquareBracket" },
                {",","comma" },
                {";","semi colon" }
            };

            foreach (KeyValuePair<string, string> s in DictSymbol)
            {
                if (s.Key == SplittedString)
                {
                    return DictSymbol[SplittedString];
                }
            }
            return null;
        }

        public string Operators(string SplittedString)             // Function for recognizing Operators...
        {
            Dictionary<string, string> dictOperator = new Dictionary<string, string>()
            {
                {"+","AdditionOperator" },
                {"-","SubtractionOperator" },
                {"*", "MultiplicationOperator"},
                {"/","DivisionOperator" },
                {"%","ModulusOperator" },
                {"=","AssignmentOperator" },
                {"==","EqualToOperator" },
                {">","GreaterThanOperator" },
                {"<","LessThanOperator" },
                {">=","GreaterThanOrEqualToOperator" },
                {"<=","LessThanOrEqualToOperator" },
                {"!=","NotEqualToOperator" },
                {"||","OROperator" },
                {"&&","ANDOperator" },
                {"++","IncrementOperator" },
                {"--","DecrementOperator" },
                {"!","NotOperator" },
                {"~","BitwiseCompliment"},
                {"&","BitwiseAND" },
                {"|","BitwiseOR" },
                {"^","BitwiseExclusiveOR" },
                {"<<","BitwiseLeftShift" },
                {">>","BitwiseRightShift" },
                {"+=","AdditionAssignment" },
                {"-=","SubtractionAssignment" },
                {"*=","MultiplicationAssignment" },
                {"/=","DivisionAssignment" },
                {"%=","ModuloAssignment" },
                {"&=","BitwiseANDassignment" },
                {"|=","BitwiseORassignment" },
                {"^=","BitwiseXORassignment" },
                {"<<=","Left shiftAssignment" },
                {">>=","Right shiftAssignment" },
                {"?:","ConditionalExpression" } 	
            };

            foreach (KeyValuePair<string, string> s in dictOperator)
            {
                if (s.Key == SplittedString)
                {
                    return dictOperator[SplittedString];
                }
            }
            return null;
        }

        public string DataType(string SplittedString)
        {
            string check = SplittedString;
            byte[] converted = Encoding.ASCII.GetBytes(check);

            foreach (byte element in check)
            {

                if (element >= 48 && element <= 57)
                {
                    if (check.Contains("."))
                    {
                        return "Float";
                    }
                    else
                    {
                        return "Integer";
                    }
                }

                else if (check.ToLower() == "true" || check.ToLower() == "false")
                {
                    return "Bool";
                }

                else
                {
                    return "Identifier";
                }
            }
            return null;
        }
    }
}
