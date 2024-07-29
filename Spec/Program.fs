module App
open Domain
open Microsoft.SemanticKernel
open Gail
let template = Template @"{{$input}}
One line TLDR with the fewest words."
let input = @"
1st Law of Thermodynamics - Energy cannot be created or destroyed.
2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy."

let plan = Gail.prepPlan template
let mutable funArg = KernelArguments()
funArg.Item "input" <-  input


let res =
    plan funArg
    |> _.Result
    |> fun fRes -> fRes.GetValue()
printfn $"%s{res}"












// let text2 = @"
// 1. An object at rest remains at rest, and an object in motion remains in motion at constant speed and in a straight line unless acted on by an unbalanced force.
// 2. The acceleration of an object depends on the mass of the object and the amount of force applied.
// 3. Whenever one object exerts a force on another object, the second object exerts an equal and opposite on the first.";
// let args2 = KernelArguments()
// args2.Item("input")  <- text2
// let localKernel2 = kernel()
// let res2 = localKernel2.InvokeAsync(promptSum, args2).Result
// printfn $"%s{res2.GetValue()}"