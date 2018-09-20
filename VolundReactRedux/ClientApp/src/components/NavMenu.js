import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
  <Navbar inverse fixedTop fluid collapseOnSelect>
    <Navbar.Header>
      <Navbar.Brand>
        <Link to={'/'}>VolundApp</Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
    <Navbar.Collapse>
      <Nav>
        <LinkContainer to={'/'} exact>
          <NavItem>
            <Glyphicon glyph='home' /> Home
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/backlog/index'}>
            <NavItem>
                <Glyphicon glyph='th-list' /> Backlog
            </NavItem>
        </LinkContainer>
        <LinkContainer to={'/Backlog/CreateBacklogGame'}>
            <NavItem>
                <Glyphicon glyph='th-list' /> Add backlog game
            </NavItem>
        </LinkContainer>
                <LinkContainer to={'/Backlog/CreateFinishedGame'}>
            <NavItem>
                <Glyphicon glyph='th-list' /> Add finished game
            </NavItem>
        </LinkContainer>
        <LinkContainer to={'/counter'}>
          <NavItem>
            <Glyphicon glyph='education' /> Counter
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/fetchdata'}>
          <NavItem>
            <Glyphicon glyph='th-list' /> Fetch data
          </NavItem>
        </LinkContainer>
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);
