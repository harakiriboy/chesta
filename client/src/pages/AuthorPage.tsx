import AuthorMain from '../features/Author/AuthorMain'
import AuthorEmpty from '../features/Author/AuthorEmpty'
import { Outlet, useLocation } from 'react-router-dom'
import AuthorPublications from '../features/Author/AuthorPublications';
import { useEffect } from 'react';

export interface locationProps {
  location: string;
}

function AuthorPage() {
  const location = useLocation();
  return (
    <div style={{height: '100%'}}>
      <div style={{position: 'relative', height: '200px', overflow: 'hidden', background: 'url(https://i.pinimg.com/originals/da/4e/8a/da4e8aee8cb41b8bda58c8dd48f65c62.jpg) no-repeat center', backgroundSize: 'cover'}}></div>
      <div style={{position: 'absolute', width: '100%', minHeight: '100vh', marginTop: '-25px'}}>
          <AuthorMain />
          <AuthorEmpty/>
            {(location.pathname.includes('membership') || 
            (location.pathname.includes('about')) || 
            (location.pathname.includes('posts'))) ? (
              <div>
                <Outlet/>
              </div>
            ) : (
              <AuthorPublications />
            )}
      </div>
    </div>
  )
}

export default AuthorPage