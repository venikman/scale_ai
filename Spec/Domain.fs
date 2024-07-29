module Domain

open Microsoft.SemanticKernel

// type Answer = Answer of string
type Query = | Query of string
type Template = Template of string

// type AnswerToQuery = Answer -> Query
// type CombineQueryAndPrompt = Template -> Query -> Query
// type CombineQueryAndPrompt = Template -> Query -> Query

type GailEngin = GailEngine of Kernel
type GailFunction = GailFunction of KernelFunction

type Plan = GailFunction seq

