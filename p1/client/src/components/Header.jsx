import PropTypes from 'prop-types'

const Header = ({ title }) => {
  return (
    <h1 className="text-4xl font-bold">{title}</h1>
  )
}

export default Header

Header.propTypes = {
  title: PropTypes.string.isRequired
}