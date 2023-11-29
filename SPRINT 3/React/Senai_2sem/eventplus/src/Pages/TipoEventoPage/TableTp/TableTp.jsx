import React from 'react';
import './TableTp.css';
import editPen from '../../../assets/images/images/edit-pen.svg'
import trashDelete from '../../../assets/images/images/trash-delete.svg'

const TableTp = ({dados, fnUpdate, fnDelete}) => {
    return (
        <table className='table-data'>
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Título</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>



            <tbody>
                {dados.map((tipoEvento) =>(
                    <tr className="table-data__head-row">
                    <td className="table-data__data table-data__data--big">
                        {tipoEvento.titulo}
                    </td>

                    <td className="table-data__data table-data__data--little">
                        <img className="table-data__icon" onClick={() => {fnUpdate(tipoEvento)}} src={editPen} alt="" />
                    </td>

                    <td className="table-data__data table-data__data--little">
                        <img className="table-data__icon" onClick={() => {fnDelete(tipoEvento.idTipoEvento)}} src={trashDelete} alt="" />
                    </td>
                </tr>

                ))}
                
            </tbody>
        </table>
    );
};

export default TableTp;