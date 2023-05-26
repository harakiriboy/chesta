import { useLocation } from 'react-router-dom';
import './AuthorMain.css';

function AuthorMain() {
    var location = useLocation();
    var authorname = location.pathname.substring(1);
    if (location.pathname.includes('post') || location.pathname.includes('about') || location.pathname.includes('membership')) {
        authorname = authorname.split('/')[0];
    }
    return (
        <>
            <div className="row">
                <div className="column">
                    {/* <p style={{position: 'absolute', bottom: 0, left: '50px'}}></p> */}
                </div>
                <div className="column">
                    <div className="row">
                    <div style={{width: '80px', height: '80px', borderRadius: '50%',
                        backgroundColor: 'red', margin: '0 auto'}}>
                    </div>
                    </div>
                    <div className="row">
                        <p style={{fontSize: '16px', fontWeight: 'bold', margin: '5px auto'}}>{authorname}</p>
                    </div>
                    <div className="row">
                        <p style={{fontSize: '15px', margin: '5px auto'}}>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Optio dolor eos, voluptatum, perspiciatis unde quibusdam.</p>
                    </div>
                </div>
                <div></div>
            </div>
        </>
    )
}

export default AuthorMain