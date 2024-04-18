import { Link } from "react-router-dom";
import backgroundImage from "../assets/greenindexcard.jpg";
const Landing = () => {
  return (
    <div
      className="hero min-h-screen"
      style={{
        backgroundImage: `url(${backgroundImage})`,
      }}
    >
      <div className="hero-overlay bg-opacity-20"></div>
      <div className="hero-content text-center text-neutral">
        <div className="max-w-x2l">
          <h1 className="mb-14 text-6xl font-bold">
            Welcome to <span className="text-amber-400">Quiz App</span>
          </h1>
          <p className="mb-9 text-2xl font-semibold">
            Create quizzes and get prepared for exams and qc&apos;s
          </p>
          <Link
            to="/signup"
            className="btn bg-zinc-600 text-amber-400 border-amber-400 w-48 text-lg hover:bg-amber-400 hover:text-zinc-600 hover:scale-110 hover:border-zinc-600"
          >
            Get Started
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Landing;
