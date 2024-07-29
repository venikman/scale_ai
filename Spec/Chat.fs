module Gail
open System.Text.Json
open Domain
open Microsoft.SemanticKernel
open Microsoft.SemanticKernel.ChatCompletion
let K =
    Kernel.CreateBuilder()
    |> _.AddOpenAIChatCompletion("gpt-4o-mini","KEY")
    |> _.Build()
let prepPlan (temp: Template) =
    let templateJsonConf = """
        {
            "schema": 1,
            "name": "HelloAI",
            "description": "Say hello to an AI",
            "type": "completion",
            "completion": {
                "max_tokens": 256,
                "temperature": 0.5,
                "top_p": 0.0,
                "presence_penalty": 0.0,
                "frequency_penalty": 0.0
            }
        }
    """
    let promptConfig =
        JsonSerializer.Deserialize<PromptTemplateConfig>(templateJsonConf)
    let (Template template) = temp
    promptConfig.Template <- template
    K.CreateFunctionFromPrompt(promptConfig)
    |> fun KF (input: KernelArguments) -> KF.InvokeAsync(K, arguments = input)