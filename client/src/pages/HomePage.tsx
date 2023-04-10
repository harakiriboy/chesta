import "../App.css";

const HomePage: React.FC = () => {
  return (
      <div className="App">
        <div className="hero">
          <h1>Learn New Skills Online</h1>
          <p>Get ahead with online courses from top institutions around the world. Choose from thousands of courses in IT, business, and more.</p>
          <a href="/" className="button primary">Start Learning</a>
        </div>
        <div className="featured">
          <h2>Featured Courses</h2>
          <div className="card">
            <img src="https://cdn.pixabay.com/photo/2022/04/05/14/13/flower-7113735_960_720.jpg" alt="Course" />
            <h3>Learn Python Programming</h3>
            <p>Master the fundamentals of Python and apply them to real-world projects.</p>
            <a href="/" className="button primary">View Course</a>
          </div>
          <div className="card">
            <img src="https://cdn.pixabay.com/photo/2023/02/05/16/32/cactus-7769916_960_720.jpg" alt="Course" />
            <h3>Web Development Bootcamp</h3>
            <p>Build dynamic web applications using HTML, CSS, and JavaScript.</p>
            <a href="/" className="button primary">View Course</a>
          </div>
          <div className="card">
            <img src="https://cdn.pixabay.com/photo/2023/03/31/14/16/pine-needles-7890105_960_720.jpg" alt="Course" />
            <h3>Introduction to Data Science</h3>
            <p>Explore the basics of data science, including statistical analysis and data visualization.</p>
            <a href="/" className="button primary">View Course</a>
          </div>
        </div>
        <div className="cta">
          <h2>Get Started Today</h2>
          <p>Join the millions of students already learning on Udemy.</p>
          <a href="/" className="button primary">Sign up now</a>
        </div>
        <footer>
          <p>&copy; 2023 Udemy Inc.</p>
        </footer>
      </div>
    );
  };

export default HomePage;