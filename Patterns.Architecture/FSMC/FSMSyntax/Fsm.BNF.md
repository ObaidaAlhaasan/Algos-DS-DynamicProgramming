- "-" means empty or not defined-exist

<FSM> ::= <header>* <logic>
<header> ::= <name> ":" <name>

<logic> ::="{" <transition>* "}"
<transition> ::= <state-sepc> <subtransition> | <state-spec> "{" <subtransition>* "}"

<state-sepc> :== <state> <state-modifier>*

<state> ::= <name> | "(" <name> ")"

<state-modifier> :== ":" <name>   
                 |   "<" <name>  
                 |   ">" <name>

<subtransition> :: <event> <next-state> <action>
<action> ::= <name> | "{" <name>* "}" | "-"

<next-state> ::= <state> | "-" 

<event> ::= <name> | "-"


