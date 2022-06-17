namespace ConsenSys.QBS.Web.Models;

public class QbsApiResponseModel
{
    public ConsortiumCollection Consortiums { get; set; }

    public ConsortiumMemberCollection ConsortiumMembers { get; set; }

    public Invite Invite { get; set; }
}
