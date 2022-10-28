private void When( MeetingFeeCanceledDomainEvent meetingFeeCanceled )	
	{
	    _status = MeetingFeeStatus.Of(meetingFeeCanceled.Status);
	}
	
	private void When( MeetingFeeExpiredDomainEvent meetingFeeExpired )
	{
	    _status = MeetingFeeStatus.Of(meetingFeeExpired.Status);
        _broadcast.Inform.That( Alert.Build( meetingFeeExpired.ExpirationDateTime.timeSinceNow()) );
	}
	
	private void When( MeetingFeePaidDomainEvent meetingFeePaid )
	{
	    _status = MeetingFeeStatus.Of(meetingFeePaid.Status);
        similarThingsHappen();
	}


 private static Physician CreatePhysician(HealthcarePractitionerState state)
        {
            return new Physician
            (
                state.Identifier,
                FullName.FromState(state.FullName),
                new BelgianHealthcarePractitionerLicenseNumber(state.LicenseNumber),
                BelgianSocialSecurityNumber.CreateIfNotEmpty(state.SocialSecurityNumber),
                ContactInformation.FromState(state.ContactInformation),
                state.Speciality,
                state.DisplayName
            );
        }