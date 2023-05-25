import './AuthorMain.css';

function AuthorMain() {
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
                        <p style={{fontSize: '16px', fontWeight: 'bold', margin: '5px auto'}}>harakiriboy</p>
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