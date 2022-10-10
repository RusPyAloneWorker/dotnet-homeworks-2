open Hw4.Parser
open Hw4.Calculator


let args = [|"4"; "+"; "5"|]

let res = parseCalcArguments args 

let d = calculate res.arg1 res.operation res.arg2 

printf "%f" d