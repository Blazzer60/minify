import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { minifies: [], loading: true };
  }

  componentDidMount() {
    this.populateMinifyData();
  }

  renderMinifyTable(minifies) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Key</th>
            <th>Url</th>
            <th>ACtion</th>
          </tr>
        </thead>
        <tbody>
          {minifies.map(minify =>
            <tr key={minify.key}>
              <td>{minify.key}</td>
              <td>{minify.url}</td>
              <td><input type="button" value="supprimer" onClick={ this.delete.bind(this, minify.key)} /></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderMinifyTable(this.state.minifies);

    return (
      <div>
        <h1 id="tabelLabel" >Minify</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateMinifyData() {
    const response = await fetch('minify');
    const data = await response.json();
    this.setState({ minifies: data, loading: false });
  }

  delete = async (id) =>{
        const requestOptions = {
            method: 'DELETE'
        };
        await fetch('minify/'+id, requestOptions);
        this.populateMinifyData();
    }
}
