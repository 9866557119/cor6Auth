﻿using Globomantics.Shared;

namespace Globomantics.Api.Repositories;

public class ProposalRepository : IProposalRepository
{
    private static List<ProposalModel> proposals = new() {
        new ProposalModel { Id = 1, ConferenceId = 1, Title = "Authentication and Authorization in ASP.NET Core", Speaker = "Roland Guijt" },
        new ProposalModel { Id = 2, ConferenceId = 1, Title = "ASP.NET Core Basics", Speaker = "Alice Waterman" },
        new ProposalModel { Id = 3, ConferenceId = 2, Title = "Writing CSS Like a Boss", Speaker = "Deborah Midland" },
    };
    public IEnumerable<ProposalModel> GetAllForConference(int conferenceId)
    {
        return proposals.Where(p => p.ConferenceId == conferenceId);
    }

    public int Add(ProposalModel model)
    {
        model.Id = proposals.Max(p => p.Id) + 1;
        proposals.Add(model);
        return model.Id;
    }

    public ProposalModel? Approve(int proposalId)
    {
        var proposal = proposals.FirstOrDefault(p => p.Id == proposalId);
        if (proposal != null)
            proposal.Approved = true;
        return proposal;
    }

    public ProposalModel? GetOne(int id)
    {
        return proposals.FirstOrDefault(p => p.Id == id);
    }
}
