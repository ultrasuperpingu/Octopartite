﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Octopartite.ParserRules
{
	public abstract class Rule
	{
		public static bool DefaultBacktrackCardinalityOps { get; set; } = false;
		public bool BacktrackCardinalityOps { get; set; } = DefaultBacktrackCardinalityOps;
		public static bool DefaultBacktrackChoices { get; set; } = false;
		public bool BacktrackChoices { get; set; } = DefaultBacktrackChoices;
		public abstract bool IsTerminal { get; }
		public abstract ParseNode Parse(string input, int index, List<Terminal> skips);
		internal abstract ParseNode Backtrack(ParseNode node, List<Terminal> skips);
		public abstract List<Terminal> GetFirstTerminals();
		public string Name { get; set; }
	}
}
