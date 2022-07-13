public class OnTargetAppearedEvent : Event<OnTargetAppearedEvent> { }
public class OnRoundEndEvent : Event<OnRoundEndEvent> { }
public class OnRoundBeginEvent : Event<OnRoundBeginEvent> { public int newRound; }

public enum TargetType { Nothing, Decoy, Target}
public class OnClickedEvent : Event<OnClickedEvent> { public TargetType target; }
public class OnGameOverEvent : Event<OnGameOverEvent> { }
