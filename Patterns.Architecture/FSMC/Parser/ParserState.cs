namespace Patterns.Architecture.FSMC.Parser
{
    public enum ParserState
    {
        HEADER,
        HEADERColon,
        StateSpec,
        HEADERValue,
        SuperStateName,
        StateModifier,
        End,
        GroupNextState,
        GroupActionGroup,
        GroupActionGroupName,
        SubTransitionGroup,
        SuperStateClose,
        ExitAction,
        EntryAction,
        StateBase,
        SingleEvent,
        SingleNextState
    }
}