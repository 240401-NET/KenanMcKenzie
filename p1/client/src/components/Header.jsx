import PropTypes from "prop-types";

const Header = ({ title }) => {
  return (
    <h1 className="text-center font-mono text-5xl font-bold pt-16 pb-12 text-neutral">
      {title}
    </h1>
  );
};

export default Header;

Header.propTypes = {
  title: PropTypes.string.isRequired,
};
