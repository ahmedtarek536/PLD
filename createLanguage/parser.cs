
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF          =  0, // (EOF)
        SYMBOL_ERROR        =  1, // (Error)
        SYMBOL_WHITESPACE   =  2, // Whitespace
        SYMBOL_MINUS        =  3, // '-'
        SYMBOL_MINUSMINUS   =  4, // '--'
        SYMBOL_EXCLAMEQ     =  5, // '!='
        SYMBOL_PERCENT      =  6, // '%'
        SYMBOL_LPAREN       =  7, // '('
        SYMBOL_RPAREN       =  8, // ')'
        SYMBOL_TIMES        =  9, // '*'
        SYMBOL_TIMESTIMES   = 10, // '**'
        SYMBOL_COMMA        = 11, // ','
        SYMBOL_DIV          = 12, // '/'
        SYMBOL_COLON        = 13, // ':'
        SYMBOL_PLUS         = 14, // '+'
        SYMBOL_PLUSPLUS     = 15, // '++'
        SYMBOL_LT           = 16, // '<'
        SYMBOL_LTEQ         = 17, // '<='
        SYMBOL_EQ           = 18, // '='
        SYMBOL_EQEQ         = 19, // '=='
        SYMBOL_GT           = 20, // '>'
        SYMBOL_GTEQ         = 21, // '>='
        SYMBOL_ALPH         = 22, // Alph
        SYMBOL_ELSE         = 23, // else
        SYMBOL_END          = 24, // End
        SYMBOL_FOR          = 25, // for
        SYMBOL_ID           = 26, // Id
        SYMBOL_IF           = 27, // if
        SYMBOL_IN           = 28, // in
        SYMBOL_NUMBER       = 29, // Number
        SYMBOL_PRINT        = 30, // print
        SYMBOL_RANGE        = 31, // range
        SYMBOL_START        = 32, // Start
        SYMBOL_ASSIGN       = 33, // <assign>
        SYMBOL_COMP_OP      = 34, // <comp_op>
        SYMBOL_COND         = 35, // <cond>
        SYMBOL_EXP          = 36, // <exp>
        SYMBOL_EXPR         = 37, // <expr>
        SYMBOL_FACTOR       = 38, // <factor>
        SYMBOL_FOR_STMT     = 39, // <for_stmt>
        SYMBOL_ID2          = 40, // <id>
        SYMBOL_IF_STMT      = 41, // <if_stmt>
        SYMBOL_INC_DEC_STMT = 42, // <inc_dec_stmt>
        SYMBOL_NUMBER2      = 43, // <number>
        SYMBOL_POSTFIX_OP   = 44, // <postfix_op>
        SYMBOL_PREFIX_OP    = 45, // <prefix_op>
        SYMBOL_PRINT_STMT   = 46, // <print_stmt>
        SYMBOL_PROGRAM      = 47, // <Program>
        SYMBOL_RANGE_ARGS   = 48, // <range_args>
        SYMBOL_STMT         = 49, // <stmt>
        SYMBOL_STMT_LIST    = 50, // <stmt_list>
        SYMBOL_STRING       = 51, // <string>
        SYMBOL_TERM         = 52  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                       =  0, // <Program> ::= Start <stmt_list> End
        RULE_STMT_LIST                                               =  1, // <stmt_list> ::= <stmt>
        RULE_STMT_LIST2                                              =  2, // <stmt_list> ::= <stmt> <stmt_list>
        RULE_STMT                                                    =  3, // <stmt> ::= <assign>
        RULE_STMT2                                                   =  4, // <stmt> ::= <if_stmt>
        RULE_STMT3                                                   =  5, // <stmt> ::= <for_stmt>
        RULE_STMT4                                                   =  6, // <stmt> ::= <inc_dec_stmt>
        RULE_STMT5                                                   =  7, // <stmt> ::= <print_stmt>
        RULE_ASSIGN_EQ                                               =  8, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                                   =  9, // <id> ::= Id
        RULE_EXPR_PLUS                                               = 10, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                              = 11, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                    = 12, // <expr> ::= <term>
        RULE_TERM_TIMES                                              = 13, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                = 14, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                            = 15, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                    = 16, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                       = 17, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                                  = 18, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                       = 19, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                     = 20, // <exp> ::= <id>
        RULE_EXP2                                                    = 21, // <exp> ::= <number>
        RULE_EXP3                                                    = 22, // <exp> ::= <string>
        RULE_NUMBER_NUMBER                                           = 23, // <number> ::= Number
        RULE_STRING_ALPH                                             = 24, // <string> ::= Alph
        RULE_PRINT_STMT_PRINT_LPAREN_RPAREN                          = 25, // <print_stmt> ::= print '(' <expr> ')'
        RULE_IF_STMT_IF_COLON                                        = 26, // <if_stmt> ::= if <cond> ':' <stmt_list>
        RULE_IF_STMT_IF_COLON_ELSE_COLON                             = 27, // <if_stmt> ::= if <cond> ':' <stmt_list> else ':' <stmt_list>
        RULE_COND                                                    = 28, // <cond> ::= <expr> <comp_op> <expr>
        RULE_COMP_OP_LT                                              = 29, // <comp_op> ::= '<'
        RULE_COMP_OP_GT                                              = 30, // <comp_op> ::= '>'
        RULE_COMP_OP_EQEQ                                            = 31, // <comp_op> ::= '=='
        RULE_COMP_OP_EXCLAMEQ                                        = 32, // <comp_op> ::= '!='
        RULE_COMP_OP_LTEQ                                            = 33, // <comp_op> ::= '<='
        RULE_COMP_OP_GTEQ                                            = 34, // <comp_op> ::= '>='
        RULE_FOR_STMT_FOR_LPAREN_IN_RANGE_LPAREN_RPAREN_RPAREN_COLON = 35, // <for_stmt> ::= for '(' <id> in range '(' <range_args> ')' ')' ':' <stmt_list>
        RULE_RANGE_ARGS                                              = 36, // <range_args> ::= <expr>
        RULE_RANGE_ARGS_COMMA                                        = 37, // <range_args> ::= <expr> ',' <expr>
        RULE_RANGE_ARGS_COMMA_COMMA                                  = 38, // <range_args> ::= <expr> ',' <expr> ',' <expr>
        RULE_INC_DEC_STMT                                            = 39, // <inc_dec_stmt> ::= <prefix_op> <id>
        RULE_INC_DEC_STMT2                                           = 40, // <inc_dec_stmt> ::= <id> <postfix_op>
        RULE_PREFIX_OP_PLUSPLUS                                      = 41, // <prefix_op> ::= '++'
        RULE_PREFIX_OP_MINUSMINUS                                    = 42, // <prefix_op> ::= '--'
        RULE_POSTFIX_OP_PLUSPLUS                                     = 43, // <postfix_op> ::= '++'
        RULE_POSTFIX_OP_MINUSMINUS                                   = 44  // <postfix_op> ::= '--'
    };

    public class MyParser
    {
        private LALRParser parser;
        private ListBox _listBox;
        private ListBox _listBox2;

        public MyParser(string filename, ListBox listBox, ListBox listBox2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            _listBox = listBox;
            _listBox2 = listBox2;
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "  \t \t" + (SymbolConstants)args.Token.Symbol.Id;
            _listBox2.Items.Add(info);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ALPH :
                //Alph
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //Number
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE :
                //range
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMP_OP :
                //<comp_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INC_DEC_STMT :
                //<inc_dec_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER2 :
                //<number>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POSTFIX_OP :
                //<postfix_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PREFIX_OP :
                //<prefix_op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STMT :
                //<print_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANGE_ARGS :
                //<range_args>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //<string>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<Program> ::= Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <stmt> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT :
                //<stmt> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT2 :
                //<stmt> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT3 :
                //<stmt> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT4 :
                //<stmt> ::= <inc_dec_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT5 :
                //<stmt> ::= <print_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <number>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP3 :
                //<exp> ::= <string>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMBER_NUMBER :
                //<number> ::= Number
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRING_ALPH :
                //<string> ::= Alph
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STMT_PRINT_LPAREN_RPAREN :
                //<print_stmt> ::= print '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON :
                //<if_stmt> ::= if <cond> ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_COLON_ELSE_COLON :
                //<if_stmt> ::= if <cond> ':' <stmt_list> else ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <comp_op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_LT :
                //<comp_op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_GT :
                //<comp_op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_EQEQ :
                //<comp_op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_EXCLAMEQ :
                //<comp_op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_LTEQ :
                //<comp_op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_OP_GTEQ :
                //<comp_op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_IN_RANGE_LPAREN_RPAREN_RPAREN_COLON :
                //<for_stmt> ::= for '(' <id> in range '(' <range_args> ')' ')' ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGE_ARGS :
                //<range_args> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGE_ARGS_COMMA :
                //<range_args> ::= <expr> ',' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANGE_ARGS_COMMA_COMMA :
                //<range_args> ::= <expr> ',' <expr> ',' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_DEC_STMT :
                //<inc_dec_stmt> ::= <prefix_op> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_DEC_STMT2 :
                //<inc_dec_stmt> ::= <id> <postfix_op>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PREFIX_OP_PLUSPLUS :
                //<prefix_op> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PREFIX_OP_MINUSMINUS :
                //<prefix_op> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIX_OP_PLUSPLUS :
                //<postfix_op> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIX_OP_MINUSMINUS :
                //<postfix_op> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "', In Line:" + args.UnexpectedToken.Location.LineNr;
            //todo: Report message to UI?

            _listBox.Items.Add(message);
            string m2 = "Expected token: " + args.ExpectedTokens.ToString();
            _listBox.Items.Add(m2);
        }

    }
}
