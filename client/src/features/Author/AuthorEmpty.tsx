import { Link } from 'react-router-dom';
import './AuthorEmpty.css';
import { Typography } from '@mui/material';

function AuthorEmpty() {
  return (
    <div style={{marginTop: '200px', marginBottom: '50px'}}>
      <div className='row'>
        <div className='column1'>
            <Link to="posts" style={{textDecoration: 'none', color: '#28c98e'}}>
              <Typography>
              <div style={{marginLeft: '520px'}}>Main</div>
              </Typography>
            </Link>
        </div>
        <div className='column2'>
          <Link to="about" style={{textDecoration: 'none', color: '#28c98e'}}>
            <Typography>About</Typography>
          </Link>
        </div>
        <div className='column3'>
        <Link to="membership" style={{textDecoration: 'none', color: '#28c98e'}}>
          <Typography>
          <div style={{marginRight: '520px'}}>Subscription</div>
          </Typography>
        </Link>
        </div>
      </div>
      <p style={{borderBottom: '1px solid #28c98e', paddingBottom: '20px', marginBottom: '20px'}}></p>
    </div>
  )
}

export default AuthorEmpty