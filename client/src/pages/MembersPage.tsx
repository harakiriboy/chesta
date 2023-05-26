import NoAccess from '../components/NoAccess';
import Members from '../features/Members/Members'

function MembersPage() {
  var author = localStorage.getItem('localAuthor');
  return (
    <>
      {author ? (
      <Members />
    ) : (
      <NoAccess/>
    )}
    </>
  )
}

export default MembersPage