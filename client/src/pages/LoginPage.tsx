interface LoginFormProps {
  onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}

const LoginPage: React.FC<LoginFormProps> = ({ onSubmit }) =>  {
  return (
    <form
      onSubmit={onSubmit}
      style={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        padding: '20px',
        border: '1px solid #ccc',
        borderRadius: '5px',
      }}
    >
      <input type="email" placeholder="Email Address" name="email" style={{ margin: '5px 0', padding: '10px' }} />
      <input type="password" placeholder="Password" name="password" style={{ margin: '5px 0', padding: '10px' }} />
      <button type="submit" style={{ margin: '5px 0', padding: '10px', backgroundColor: '#0066ff', color: 'white', border: 'none', borderRadius: '5px' }}>Login</button>
    </form>
  );
};

export default LoginPage