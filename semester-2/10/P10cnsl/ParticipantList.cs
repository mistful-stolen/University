using System.Diagnostics;

public class ParticipantList
{
    IParticipant[] participants;

    public ParticipantList(IParticipant[] participants)
    {
        if(participants == null) throw new ArgumentException(nameof(participants));


        this.participants = participants;

        if(!IsOrdered() || !IsUnique()) throw new NotSetException(participants, "");
    }

    public int Length => participants.Length;

    private bool IsOrdered()
    {
        for (int i = 1; i < participants.Length; i++)
        {
            if (participants[i].CompareTo(participants[i - 1]) < 0) 
                return false;
        }
        return true;
    }
    private bool IsUnique()
    {
        for (int i = 1; i < participants.Length; i++)
        {
            if (participants[i].Equals(participants[i - 1]))
                return false;
        }
        return true;
    }

    public bool Contains(object participant)
    {
        if (participants == null) throw new ArgumentNullException(nameof(participant));

        int leftIdx = 0;
        int rightIdx = participants.Length - 1;
        int centerIdx = (leftIdx + rightIdx) / 2;

        while (leftIdx <= rightIdx && !participants[centerIdx].Equals(participant))
        {
            if(participants[centerIdx].CompareTo(participant) < 0)
                leftIdx = centerIdx + 1;
            else rightIdx = centerIdx - 1;

            centerIdx = (leftIdx + rightIdx) / 2;
        }
        return leftIdx <= rightIdx;
    }

    public bool IsSubset(ParticipantList other)
    {
        if(other == null) throw new ArgumentNullException(nameof(other));

        int ownIdx = 0;
        int otheridx = 0;

        while (
            ownIdx < Length 
            && otheridx < other.Length 
            && other.participants[otheridx].CompareTo(participants[ownIdx]) >= 0)
        {
            if (other.participants[otheridx].Equals(participants[ownIdx])) otheridx++;
            ownIdx++;
        }

        return otheridx == other.Length;
    }

    public static bool IsSubset(ParticipantList list1, ParticipantList list2)
    {
        if(list1 == null) throw new ArgumentNullException(nameof(list1));
        if(list2 == null) throw new ArgumentNullException(nameof(list1));

        return list2.IsSubset(list1);
    }

    public ParticipantList Intersection(ParticipantList other)
    {
        if(other == null) throw new ArgumentNullException(nameof(other));

        IParticipant[] result = new IParticipant[Math.Min(this.Length, other.Length)];

        int ownIdx = 0;
        int otherIdx= 0;
        int resultioIdx = 0;

        while (ownIdx < Length && otherIdx < other.Length) 
        {
            if (other.participants[otherIdx].CompareTo(participants[ownIdx]) < 0) otherIdx++;
            else if (other.participants[otherIdx].CompareTo(participants[ownIdx]) > 0) ownIdx++;
            else
            {
                result[resultioIdx] = other.participants[otherIdx];
                resultioIdx++;
                ownIdx++;
                otherIdx++;
            }
        }
        

        return new ParticipantList(result);
    }
    
    public static ParticipantList Intersection(ParticipantList list1, ParticipantList list2)
    {
        if (list1 == null) throw new ArgumentNullException(nameof(list1));
        if (list2 == null) throw new ArgumentNullException(nameof(list1));

        return list1.Intersection(list2);
    }

    public ParticipantList Difference(ParticipantList other)
    {
        IParticipant[] result = new IParticipant[Length];

        int ownidx = 0;
        int otheridx = 0;
        int resultidx = 0;
        
        return new ParticipantList(participants);
    }

}