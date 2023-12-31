﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octopartite.ParserRules;


namespace Octopartite.Examples
{
	/// <summary>
	/// A really ambiguous grammar that can be parsed...
	/// </summary>
	public class VeryAmbigousGrammarParser : AbstractExample
	{
		public VeryAmbigousGrammarParser()
		{
			Rule.DefaultBacktrackCardinalityOps = true;
			Rule.DefaultBacktrackChoices = true;

			// Start Generated Code
			Terminal ID = new RegexTerminal(@"\G[a-z_][a-z_0-9]*");
			Terminal ID_SUFFIX = new RegexTerminal(@"\G[a-z_][a-z_0-9]*_SUFFIX");
			Terminal NUMBER = new RegexTerminal(@"\G[0-9]+");
			Terminal LIST = new StringTerminal(@"list");
			Terminal END = new StringTerminal(@"end");
			Terminal TEST1 = new StringTerminal(@"TEST1");
			Terminal TEST2 = new StringTerminal(@"TEST2");
			Terminal _EOF_ = new RegexTerminal(@"\G$");
			Concat List = new Concat();
			Start = new Concat();
			Terminal WHITESPACE = new RegexTerminal(@"\G\s+");
			ID.Name="ID";

			ID_SUFFIX.Name="ID_SUFFIX";

			NUMBER.Name="NUMBER";

			LIST.Name="LIST";

			END.Name="END";

			TEST1.Name="TEST1";

			TEST2.Name="TEST2";

			_EOF_.Name="_EOF_";

			List.Name="List";
			Concat concat1 = new Concat();
			Optional unary2 = new Optional();
			Choice choice3 = new Choice();
			choice3.Symbols.Add(ID);
			choice3.Symbols.Add(ID_SUFFIX);
			unary2.Symbol = choice3;
			concat1.Symbols.Add(unary2);
			Choice choice4 = new Choice();
			Concat concat5 = new Concat();
			concat5.Symbols.Add(ID);
			concat5.Symbols.Add(NUMBER);
			choice4.Symbols.Add(concat5);
			Concat concat6 = new Concat();
			concat6.Symbols.Add(LIST);
			concat6.Symbols.Add(END);
			choice4.Symbols.Add(concat6);
			concat1.Symbols.Add(choice4);
			concat1.Symbols.Add(LIST);
			ZeroOrMore unary7 = new ZeroOrMore();
			unary7.Symbol=ID;
			concat1.Symbols.Add(unary7);
			concat1.Symbols.Add(END);
			List.Symbols.Add(concat1);

			Start.Name="Start";
			Concat concat8 = new Concat();
			Choice choice9 = new Choice();
			Concat concat10 = new Concat();
			concat10.Symbols.Add(List);
			concat10.Symbols.Add(TEST1);
			choice9.Symbols.Add(concat10);
			Concat concat11 = new Concat();
			concat11.Symbols.Add(List);
			concat11.Symbols.Add(TEST2);
			choice9.Symbols.Add(concat11);
			concat8.Symbols.Add(choice9);
			concat8.Symbols.Add(_EOF_);
			Start.Symbols.Add(concat8);

			WHITESPACE.Name="WHITESPACE";
			// End Generated Code

			Skips.Add(WHITESPACE);
		}
		public static string GrammarString => @"
			ID -> R""[a-z_][a-z_0-9]*"";
			ID_SUFFIX -> R""[a-z_][a-z_0-9]*_SUFFIX"";
			NUMBER -> R""[0-9]+"";
			LIST -> @""list"";
			END -> @""end"";
			TEST1 -> @""TEST1"";
			TEST2 -> @""TEST2"";
			_EOF_ -> R""$"";
			List-> (ID|ID_SUFFIX)? (ID NUMBER|LIST END) LIST ID* END;
			Start -> (List TEST1|List TEST2) _EOF_;
			WHITESPACE -> R""\G\s+"";
		";

		public static void GenerateParserCode()
		{
			Console.WriteLine("// VeryAmbigousGrammarParser parser code: copy/paste it in VeryAmbigousGrammarParser.cs (in constructor)");
			Console.WriteLine("//  and replace line:");
			Console.WriteLine("//    \"Concat Start = new Concat();\"");
			Console.WriteLine("//  by");
			Console.WriteLine("//    \"Start = new Concat();\"");
			Console.WriteLine("// Start Generated Code");
			GrammarUtil.GenerateParserCode(GrammarString);
			Console.WriteLine("// End Generated Code");
		}
	}
}
